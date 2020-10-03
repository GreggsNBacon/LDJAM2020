using UnityEngine;

public class RotationClipping : MonoBehaviour
{
    [SerializeField] private LayerMask mask;

    Quaternion desiredRot = Quaternion.identity;

    private void Update()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        if(Physics.Raycast(ray, out var hit, 100, mask, QueryTriggerInteraction.Ignore))
        {
            desiredRot = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;

            //desiredRot = Quaternion.RotateTowards(transform.rotation, desiredRot, 45 * Time.deltaTime);
        }

        transform.rotation = desiredRot;
    }
}
