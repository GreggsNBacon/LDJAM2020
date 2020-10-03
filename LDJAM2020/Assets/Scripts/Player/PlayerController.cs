using LudumDare.View.Car;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private MainInput input;

    [SerializeField]
    private BasicMovement car;

    private float steeringAngle = 0.0f;
    private float throttleInput = 0.0f;
    // Start is called before the first frame update
    private void Awake()
    {
        input = new MainInput();
        input.Enable();
        input.Car.CarThrottle.performed += x => Throttle(x.ReadValue<float>());
        input.Car.Steering.performed += x => Steer(x.ReadValue<float>());
    }

    private void Update()
    {
        if(steeringAngle != 0.0f && input.Car.Steering.ReadValue<float>() == 0.0f)
        {
            steeringAngle = 0.0f;
            Steer(steeringAngle);
        }

        if (throttleInput != 0.0f && input.Car.CarThrottle.ReadValue<float>() == 0.0f)
        {
            throttleInput = 0.0f;
            Throttle(throttleInput);
        }
    }

    private void OnDestroy()
    {
        input.Disable();
    }

    void Throttle(float throttle)
    {
        car.Throttle(throttle);
        throttleInput = throttle;
    }

    void Steer(float steering)
    {
        car.Turn(steering);
        steeringAngle = steering;
    }
}
