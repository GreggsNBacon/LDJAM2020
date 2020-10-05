using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class FollowWall : MonoBehaviour
{
    [SerializeField]
    private Transform target = null;

    [SerializeField]
    private float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dtSpeed = Time.deltaTime * speed;
        transform.position = Vector3.Lerp(transform.position, target.position, dtSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(target.rotation.x, target.rotation.y, target.rotation.z, target.rotation.w), dtSpeed);
    }
}
