using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelRotate : MonoBehaviour
{
    public GameObject frontWheelR;
    public GameObject frontWheelL;

    [SerializeField]
    private float rotateSpeed = 100.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotateSpeed, 0, 0) * Time.deltaTime * 20);

    }
}
