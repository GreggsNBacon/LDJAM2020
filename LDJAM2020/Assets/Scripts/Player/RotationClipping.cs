using UnityEngine;
using UnityEngine.Rendering;

public class RotationClipping : MonoBehaviour
{
    [SerializeField] private LayerMask mask;

    Quaternion desiredRot = Quaternion.identity;

    private void LateUpdate()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        if(Physics.Raycast(ray, out var hit, 100, mask, QueryTriggerInteraction.Ignore))
        {
            desiredRot = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            //Debug.Log(transform.rotation.eulerAngles.magnitude / desiredRot.eulerAngles.magnitude);

            //Debug.Log();

            desiredRot = Quaternion.Lerp(transform.rotation, desiredRot, 0.5f);
        }

        transform.rotation = desiredRot;
    }
}
