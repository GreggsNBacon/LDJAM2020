using LudumDare.Core;
using LudumDare.Model;
using UnityEngine;

namespace LudumDare.View
{
    public class TestView : AbstractView
    {
        private CarModel carModel = null;

        protected override void Start()
        {
            base.Start();

            carModel = Models.GetModel<CarModel>();

            Debug.Log("Speed = " + carModel.speed);
        }
    }
}