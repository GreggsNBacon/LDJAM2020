using UnityEngine;
using LudumDare.Model;
using LudumDare.Core;

public class VisualWheelTurning : MonoBehaviour
{
    [SerializeField] private float maxAngle = 35.0f;
    [SerializeField] private Transform[] frontWheels;

    private CarModel carModel = null;

    private void Start()
    {
        carModel = Models.GetModel<CarModel>();
        carModel.OnTurningUpdated += TurningUpdated;
    }
    private void OnDestroy()
    {
        carModel.OnTurningUpdated -= TurningUpdated;
    }
    private void TurningUpdated(float turning)
    {
        float angle = maxAngle * turning;
        for (int i = 0; i < frontWheels.Length; i++)
        {
            frontWheels[i].localRotation = Quaternion.Euler(0, angle, 0);
        }
    }
}