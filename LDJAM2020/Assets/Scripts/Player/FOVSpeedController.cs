using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVSpeedController : MonoBehaviour
{

    [SerializeField]
    private BasicMovement controller;

    [SerializeField]
    private FOVModification fovController;

    // Update is called once per frame
    void LateUpdate()
    {
        fovController.SetCameraFOV(0.5f);
    }
}
