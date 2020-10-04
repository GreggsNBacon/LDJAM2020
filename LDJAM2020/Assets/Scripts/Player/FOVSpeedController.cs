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
        carModel.OnCurrentSpeedUpdated += OnCurrentSpeedUpdated;
    }

    void OnCurrentSpeedUpdated(float speed)
    {
        
        float totalSpeed = carModel.maxSpeed - carModel.minSpeed;
        float actualSpeed = carModel.currentSpeed - carModel.minSpeed;
        float percentage = actualSpeed / totalSpeed;
        fovController.SetCameraFOV(percentage);
    }

    private void OnDestroy()
    {
        carModel.OnCurrentSpeedUpdated -= OnCurrentSpeedUpdated;
    }
}