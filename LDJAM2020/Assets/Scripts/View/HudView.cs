using System;
using LudumDare.Core;
using LudumDare.Core.EventManager;
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

        private bool deathConditionMet = false;

        protected override void Start()
        {
            base.Start();

            gameModel = Models.GetModel<GameModel>();
            carModel = Models.GetModel<CarModel>();
            mphPerUnit = carModel.mphPerUnit;
            gameModel.OnLapUpdated += LapUpdated;
            carModel.OnCurrentSpeedUpdated += CurrentSpeedUpdated;

            RefreshAll();

            EventManager<Events>.RegisterEvent(Events.FailConditionMet, OnDeathConditionMet);
        }

        private void Update()
        {
            if (deathConditionMet == true)
            {
                speedText.text = (int)(carModel.currentSpeed * mphPerUnit) + " Mph";
            }
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

        private void OnDeathConditionMet(Events eventName, object[] objects)
        {
            deathConditionMet = true;
        }

        protected override void OnDestroy()
        {
            gameModel.OnLapUpdated -= LapUpdated;
            carModel.OnCurrentSpeedUpdated -= CurrentSpeedUpdated;

            EventManager<Events>.DeregisterEvent(Events.FailConditionMet, OnDeathConditionMet);
        }
    }
}