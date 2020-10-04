using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVModification : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float min = 50.0f;

    [SerializeField]
    private float max = 100.0f;

    public void SetCameraFOV(float value)
    {
        cam.fieldOfView = Mathf.Lerp(min, max, value);
    }
}
