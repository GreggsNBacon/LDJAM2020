using UnityEngine;

namespace LudumDare.View.Car
{
    public class CarBaseView : AbstractView
    {
        [SerializeField]
        private float maxTorque = 100.0f;

        [SerializeField]
        private float maxSteeringAngle = 30.0f;

        [SerializeField]
        private WheelCollider[] frontWheels;

        [SerializeField]
        private WheelCollider[] drivenWheels;

        public void SetSteering(float steer)
        {
            for (int i = 0; i < frontWheels.Length; i++)
            {
                frontWheels[i].steerAngle = maxSteeringAngle * steer;
            }
        }

        public void SetTorque(float torque)
        {
            for (int i = 0; i < drivenWheels.Length; i++)
            {
                drivenWheels[i].motorTorque = maxTorque * torque;
            }
        }
    }

}