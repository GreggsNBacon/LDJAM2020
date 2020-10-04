using LudumDare.Core.EventManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailConditionListener : MonoBehaviour
{
    private void Awake()
    {
        EventManager<Events>.RegisterEvent(Events.FailConditionMet, FailConditionMet);
    }

    private void FailConditionMet(Events arg1, object[] arg2)
    {
        SceneManager.LoadScene("EndScene");
    }

    private void OnDestroy()
    {
        EventManager<Events>.DeregisterEvent(Events.FailConditionMet, FailConditionMet);
    }
}
