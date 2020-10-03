using LudumDare.Core;
using LudumDare.Model;
using TMPro;
using UnityEngine;

namespace LudumDare.View
{
    public class HudView : AbstractView
    {
        [SerializeField] private TextMeshProUGUI lapText = null;
        
        private GameModel gameModel = null;

        protected override void Start()
        {
            base.Start();

            gameModel = Models.GetModel<GameModel>();

            gameModel.OnLapUpdated += LapUpdated;

            RefreshAll();
        }

        private void RefreshAll()
        {
            LapUpdated(gameModel.lap);
        }

        private void LapUpdated(int lap)
        {
            lapText.text = lap.ToString();
        }

        protected override void OnDestroy()
        {
            gameModel.OnLapUpdated -= LapUpdated;
        }
    }
}