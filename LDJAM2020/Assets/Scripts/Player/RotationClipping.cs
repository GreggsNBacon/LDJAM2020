using UnityEngine;
using UnityEngine.Rendering;

public class RotationClipping : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private Transform transforms;

    Quaternion desiredRot = Quaternion.identity;

    private void LateUpdate()
    {
        //Ray ray = new Ray(transform.position, -transform.up);
        //if(Physics.Raycast(ray, out var hit, 100, mask, QueryTriggerInteraction.Ignore))
        //{
        //    desiredRot = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        //    //Debug.Log(transform.rotation.eulerAngles.magnitude / desiredRot.eulerAngles.magnitude);

        //    //Debug.Log();

        //    desiredRot = Quaternion.Lerp(transform.rotation, desiredRot, 0.5f);
        //}

        //transform.rotation = desiredRot;

        //RaycastHit hit;
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

        transforms.up = interpolatedNormal;
    }
}
