using LudumDare.Core;
using LudumDare.Core.EventManager;
using LudumDare.Model;
using UnityEngine;

namespace LudumDare.Controller
{
    public class LapController : AbstractController
    {
        private GameModel gameModel = null;

        protected override void Start()
        {
            base.Start();

            gameModel = Models.GetModel<GameModel>();
            EventManager<Events>.RegisterEvent(Events.OnLap, HandleOnLap);
        }

        private void OnTriggerEnter(Collider other)
        {
            EventManager<Events>.TriggerEvent(Events.OnLap);
        }

        private void HandleOnLap(Events eventName, object[] objects)
        {
            gameModel.lap++;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            EventManager<Events>.DeregisterEvent(Events.OnLap, HandleOnLap);
        }
    }
}