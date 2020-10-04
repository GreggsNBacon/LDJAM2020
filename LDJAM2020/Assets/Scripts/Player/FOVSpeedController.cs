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
        fovController.SetCameraFOV(speed);
    }

    private void OnDestroy()
    {
        carModel.OnCurrentSpeedUpdated -= OnCurrentSpeedUpdated;
    }
}