using LudumDare.Core;
using LudumDare.Model;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace LudumDare.View
{
    public class HudView : AbstractView
    {
        [SerializeField] private TextMeshProUGUI lapText = null;
        [SerializeField] private TextMeshProUGUI speedText = null;

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
            lapText.text = lap.ToString();
            if (lap > 1)
            {
                lapCompleteEvents?.Invoke();
            }
        }

        private void CurrentSpeedUpdated(float speed)
        {
            speedText.text = (speed * mphPerUnit) + " Mph";
        }

        protected override void OnDestroy()
        {
            gameModel.OnLapUpdated -= LapUpdated;
            carModel.OnCurrentSpeedUpdated -= CurrentSpeedUpdated;
        }
    }
}