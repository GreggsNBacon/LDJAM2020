using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LudumDare.Model;
using LudumDare.Core;

public class VisualWheelTurning : MonoBehaviour
{

    [SerializeField]
    private float maxAngle = 35.0f;
    [SerializeField]
    private Transform[] frontWheels;

    private CarModel carModel = null;


    void Start()
    {
        carModel = Models.GetModel<CarModel>();
    }

    private void LateUpdate()
    {
        if (carModel != null)
        {
            float turning = carModel.rotationSpeed;
            float angle = maxAngle * turning;
            for (int i = 0; i < frontWheels.Length; i++)
            {
                frontWheels[i].localRotation = Quaternion.Euler(0, angle, 0);
            }
        }
    }
}
