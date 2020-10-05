using LudumDare.Core;
using LudumDare.Core.EventManager;
using LudumDare.Model;
using UnityEngine;

namespace LudumDare.Controller
{
    public class DeathColliderController : AbstractController
    {
        protected override void Start()
        {
            base.Start();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                EventManager<Events>.TriggerEvent(Events.FailConditionMet);
                Debug.Log("FAIL CONDITION MET");
            }
        }
    }
}