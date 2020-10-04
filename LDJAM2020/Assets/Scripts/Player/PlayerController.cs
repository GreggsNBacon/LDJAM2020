using LudumDare.Core;
using LudumDare.Model;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MainInput input = null;
    private CarModel carModel = null;

    private void Awake()
    {
        input = new MainInput();
        input.Enable();
    }

    private void Start()
    {
        carModel = Models.GetModel<CarModel>();
    }

    private void Update()
    {
        carModel.turning = input.Car.Steering.ReadValue<float>();
        carModel.throttle = input.Car.CarThrottle.ReadValue<float>();
    }

    private void OnDestroy()
    {
        input.Disable();
    }
}
