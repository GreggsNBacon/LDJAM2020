using LudumDare.Controller;
using LudumDare.Core.EventManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailController : AbstractController
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            EventManager<Events>.TriggerEvent(Events.FailConditionMet);
            Debug.Log("FAIL CONDITION MET");
        }
    }
}
