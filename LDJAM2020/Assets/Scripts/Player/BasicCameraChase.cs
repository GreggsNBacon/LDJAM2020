using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCameraChase : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float speed = 2.0f;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * speed);
    }
}
