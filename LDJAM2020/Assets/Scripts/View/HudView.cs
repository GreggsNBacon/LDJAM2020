using LudumDare.Core;
using LudumDare.Model;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LudumDare.View
{
    public class HudView : AbstractView
    {
        [SerializeField] private Text lapText = null;
        [SerializeField] private Text speedText = null;

        [SerializeField] private float mphPerUnit = 40.0f;

        [SerializeField]
        private UnityEvent lapCompleteEvents;

        private GameModel gameModel = null;
        private CarModel carModel = null;

        protected override void Start()
        {
            base.Start();

            gameModel = Models.GetModel<GameModel>();
            carModel = Models.GetModel<CarModel>();

            gameModel.OnLapUpdated += LapUpdated;
            carModel.OnCurrentSpeedUpdated += CurrentSpeedUpdated;

            RefreshAll();
        }

        private void RefreshAll()
        {
            LapUpdated(gameModel.lap);
            CurrentSpeedUpdated(carModel.currentSpeed);
        }

        private void LapUpdated(int lap)
        {
            lapText.text = "Lap: " + lap;

            if (lap > 1)
            {
                lapCompleteEvents?.Invoke();
            }
        }

        private void CurrentSpeedUpdated(float speed)
        {
            speedText.text = (int)(speed * mphPerUnit) + " Mph";
        }

        protected override void OnDestroy()
        {
            gameModel.OnLapUpdated -= LapUpdated;
            carModel.OnCurrentSpeedUpdated -= CurrentSpeedUpdated;
        }
    }
}