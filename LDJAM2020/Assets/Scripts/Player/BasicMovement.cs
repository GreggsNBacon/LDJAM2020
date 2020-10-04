using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField]
    private float minSpeed = 1.0f;
    private float boost = 1.0f;
    private float desiredValue = 0.0f;
    [SerializeField]
    private float maxBoost = 10.0f;
    [SerializeField]
    private float maxTurn = 10.0f;

    [SerializeField]
    private float rotSpeed = 10.0f;
    private float turning = 0.0f;

    [SerializeField] private LayerMask mask;

    Quaternion desiredRot = Quaternion.identity;


    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        if (!Physics.Raycast(ray, out var hit, 100, mask, QueryTriggerInteraction.Ignore))
        {
            return;
        }

        // Just in case, also make sure the collider also has a renderer
        // material and texture
        MeshCollider meshCollider = hit.collider as MeshCollider;
        if (meshCollider == null || meshCollider.sharedMesh == null)
        {
            return;
        }

        Mesh mesh = meshCollider.sharedMesh;
        Vector3[] normals = mesh.normals;
        int[] triangles = mesh.triangles;

        // Extract local space normals of the triangle we hit
        Vector3 n0 = normals[triangles[hit.triangleIndex * 3 + 0]];
        Vector3 n1 = normals[triangles[hit.triangleIndex * 3 + 1]];
        Vector3 n2 = normals[triangles[hit.triangleIndex * 3 + 2]];

        // interpolate using the barycentric coordinate of the hitpoint
        Vector3 baryCenter = hit.barycentricCoordinate;

        // Use barycentric coordinate to interpolate normal
        Vector3 interpolatedNormal = n0 * baryCenter.x + n1 * baryCenter.y + n2 * baryCenter.z;
        // normalize the interpolated normal
        interpolatedNormal = interpolatedNormal.normalized;

        // Transform local space normals to world space
        Transform hitTransform = hit.collider.transform;
        interpolatedNormal = hitTransform.TransformDirection(interpolatedNormal);

        // Display with Debug.DrawLine
        Debug.DrawRay(hit.point, interpolatedNormal);

        // Display with Debug.DrawLine
        Debug.DrawRay(hit.point, hit.normal, Color.red);

        desiredRot = Quaternion.FromToRotation(transform.up, interpolatedNormal) * transform.rotation;
        //carTransform.rotation = desiredRot;

        //transform.rotation = desiredRot;
        transform.rotation = desiredRot;
        //transform.up = interpolatedNormal;

        UpdateThrottle();

        //var localRotation = transform.localRotation;
        //localRotation = Quaternion.Euler(localRotation.x, localRotation.y + turning * rotSpeed * Time.deltaTime, localRotation.z);
        //transform.localRotation = localRotation;

        if (turning != 0)
        {
            //transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y + turning * rotSpeed * Time.deltaTime, transform.rotation.z));
            //Quaternion currentRot = transform.rotation;
            Quaternion currentRot = transform.rotation * Quaternion.Euler(transform.rotation.x, transform.rotation.y + turning * rotSpeed * Time.deltaTime, transform.rotation.z);

            transform.rotation = currentRot;
        }

        transform.position += transform.forward * (minSpeed * Time.deltaTime);

        //transform.localRotation = Quaternion.Euler(0.0f, (turning * Time.deltaTime), 0.0f) * transform.localRotation;

        //transform.position += transform.forward * (boost * maxBoost * Time.deltaTime);
        //transform.position += transform.right * (turning * Time.deltaTime);

        //transform.Translate(Vector3.forward * (minSpeed * Time.deltaTime));

        //transform.Rotate(transform.right * (turning * Time.deltaTime));

        //transform.up = interpolatedNormal;

        // transform.position += transform.forward;
    }

    void UpdateThrottle()
    {
        if(boost < desiredValue)
        {
            boost += Time.deltaTime;
        }
        else if (boost > desiredValue)
        {
            boost -= Time.deltaTime;
        }
    }

    public void Throttle(float desired)
    {
        desiredValue = desired;
        desiredValue = Mathf.Clamp(desiredValue, 0, 1);
    }

    public void Turn(float turn)
    {
        turning = turn;
        transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, rotSpeed * turn * Time.deltaTime, 0));
    }
}
