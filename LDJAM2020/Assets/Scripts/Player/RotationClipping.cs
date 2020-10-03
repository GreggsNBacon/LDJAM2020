using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationClipping : MonoBehaviour
{
    [SerializeField]
    private LayerMask mask;

    Vector3 desiredPos = Vector3.zero;
    Quaternion desiredRot;

    // Update is called once per frame
    void LateUpdate()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100, mask, QueryTriggerInteraction.Ignore))
        {
            desiredRot = Quaternion.FromToRotation(Vector3.up, hit.normal);
            desiredRot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, desiredRot.z);
            desiredPos = hit.point + (hit.normal * 1.5f);
        }

        transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRot, Time.deltaTime);


    }
}
