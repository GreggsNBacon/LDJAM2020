using LudumDare.Core;
using LudumDare.Model;
using TMPro;
using UnityEngine;

namespace LudumDare.View
{
    public class HudView : AbstractView
    {
        [SerializeField] private TextMeshProUGUI lapText = null;
        [SerializeField] private TextMeshProUGUI speedText = null;

        [SerializeField] private float mphPerUnit = 40.0f;

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