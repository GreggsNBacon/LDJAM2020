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
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                EventManager<Events>.TriggerEvent(Events.OnLap);
                gameModel.lap++;
            }
        }



        protected override void OnDestroy()
        {
            base.OnDestroy();

        }
    }
}