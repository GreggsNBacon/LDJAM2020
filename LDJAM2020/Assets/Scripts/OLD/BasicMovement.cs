using System;
using System.Collections;
using System.Collections.Generic;
using LudumDare.Core;
using LudumDare.Model;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    //[SerializeField]
    //private float minSpeed = 1.0f;
    //[SerializeField]
    //private float maxSpeed = 14.0f;

    //private float speed = 1.0f;
    //private float boost = 1.0f;
    //private float desiredValue = 0.0f;
    //[SerializeField]
    //private float maxBoost = 10.0f;

    //[SerializeField]
    //private float rotSpeed = 10.0f;
    //private float turning = 0.0f;

    [SerializeField] private LayerMask mask;

    [SerializeField]
    private float minDistance = 0.1f;

    [SerializeField]
    private float fallSpeed = 2.0f;

    Quaternion desiredRot = Quaternion.identity;

    private CarModel carModel = null;

    public float GetSpeed()
    {
        float total = carModel.maxSpeed - carModel.minSpeed;
        float actual = carModel.maxSpeed - carModel.currentSpeed;

        return actual / total;
    }

    //public void UpdateSpeed(float percentage)
    //{
    //    float total = carModel.maxSpeed - carModel.minSpeed;
    //    float newSpeed = total * percentage;
    //    newSpeed += carModel.minSpeed;
    //    speed = newSpeed;
    //}

    private void Start()
    {
        carModel = Models.GetModel<CarModel>();

        //speed = carModel.minSpeed;

        carModel.OnTurningUpdated += OnTurningUpdated;
    }

    private void Update()
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

        Debug.DrawRay(hit.point, interpolatedNormal);
        Debug.DrawRay(hit.point, hit.normal, Color.red);

        desiredRot = Quaternion.FromToRotation(transform.up, interpolatedNormal) * transform.rotation;
        //carTransform.rotation = desiredRot;

        //transform.rotation = desiredRot;
        transform.rotation = desiredRot;
        //transform.up = interpolatedNormal;

        //UpdateThrottle();

        //var localRotation = transform.localRotation;
        //localRotation = Quaternion.Euler(localRotation.x, localRotation.y + turning * rotSpeed * Time.deltaTime, localRotation.z);
        //transform.localRotation = localRotation;
        //Debug.Log(carModel.turning);
        //if (carModel.turning != 0.0f)
        //{
        //    //transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y + turning * rotSpeed * Time.deltaTime, transform.rotation.z));
        //    //Quaternion currentRot = transform.rotation;
        //    //Quaternion currentRot = transform.rotation * Quaternion.Euler(transform.rotation.x, transform.rotation.y + turning * rotSpeed * Time.deltaTime, transform.rotation.z);

        //    //transform.rotation *= Quaternion.AngleAxis(carModel.turning * carModel.rotationSpeed * Time.deltaTime, Vector3.up);
        //}

        UpdateForwardMovement();
        UpdateFalling(hit.distance, hit.point);


        //transform.localRotation = Quaternion.Euler(0.0f, (turning * Time.deltaTime), 0.0f) * transform.localRotation;

        //transform.position += transform.forward * (boost * maxBoost * Time.deltaTime);
        //transform.position += transform.right * (turning * Time.deltaTime);

        //transform.Translate(Vector3.forward * (minSpeed * Time.deltaTime));

        //transform.Rotate(transform.right * (turning * Time.deltaTime));

        //transform.up = interpolatedNormal;

        // transform.position += transform.forward;
    }

    //void UpdateThrottle()
    //{
    //    if(boost < desiredValue)
    //    {
    //        boost += Time.deltaTime;
    //    }
    //    else if (boost > desiredValue)
    //    {
    //        boost -= Time.deltaTime;
    //    }
    //}

    //public void Throttle(float desired)
    //{
    //    desiredValue = desired;
    //    desiredValue = Mathf.Clamp(desiredValue, 0, 1);
    //}

    //public void Turn(float turn)
    //{
    //    turning = turn;
    //    //transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, rotSpeed * turn * Time.deltaTime, 0));
    //}

    private void UpdateForwardMovement()
    {
        transform.position += transform.forward * (carModel.currentSpeed * Time.deltaTime);
    }

    private void UpdateFalling(float distance, Vector3 hitPoint)
    {
        if (distance >= minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, hitPoint, fallSpeed * Time.deltaTime);
        }
    }

    private void OnTurningUpdated(float turning)
    {
        if (turning != 0.0f)
        {
            transform.rotation *= Quaternion.AngleAxis(turning * carModel.rotationSpeed * Time.deltaTime, Vector3.up);
        }
    }

    private void OnThrottleUpdated(float throttle)
    {
    }

    private void OnDestroy()
    {
        carModel.OnTurningUpdated -= OnTurningUpdated;
    }
}
