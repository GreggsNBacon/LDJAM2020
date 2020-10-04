using System;
using LudumDare.Core;
using LudumDare.Model;
using UnityEngine;

public class FOVSpeedController : MonoBehaviour
{
    [SerializeField] private FOVModification fovController;

    private CarModel carModel = null;

    private void Start()
    {
        carModel = Models.GetModel<CarModel>();
    }

    void LateUpdate()
    {
        fovController.SetCameraFOV(carModel.currentSpeed);
    }
}