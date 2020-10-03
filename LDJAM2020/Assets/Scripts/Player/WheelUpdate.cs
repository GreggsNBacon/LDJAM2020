using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelUpdate : MonoBehaviour
{
    [SerializeField]
    private WheelCollider col;

    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        Quaternion quat = transform.rotation;
        col.GetWorldPose(out pos, out quat);
        transform.position = pos;
        transform.rotation = quat;
    }
}
