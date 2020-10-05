using LudumDare.Core;
using LudumDare.Model;
using UnityEngine;

namespace LudumDare.Controller.Car
{
    public class CarController : AbstractController
    {
        [SerializeField] private float minSpeed = 5.0f;
        [SerializeField] private float maxSpeed = 14.0f;
        [SerializeField] private float maxBoost = 10.0f;
        [SerializeField] private float rotationSpeed = 150.0f;
        [SerializeField] private float fallSpeed = 2.0f;
        [SerializeField] private float minGroundDistance = 0.1f;
        [SerializeField] private float mphPerUnit = 40.0f;

        private CarModel carModel = null;

        protected override void Start()
        {
            base.Start();

            carModel = Models.GetModel<CarModel>();

            if (carModel != null)
            {
                InitializeData();
            }
        }

        private void InitializeData()
        {
            carModel.minSpeed = minSpeed;
            carModel.maxSpeed = maxSpeed;
            carModel.maxBoost = maxBoost;
            carModel.rotationSpeed = rotationSpeed;
            carModel.fallSpeed = fallSpeed;
            carModel.minGroundDistance = minGroundDistance;

            carModel.currentSpeed = minSpeed;
            carModel.mphPerUnit = mphPerUnit;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (carModel != null)
            {
                InitializeData();
            }
        }
#endif
    }
}