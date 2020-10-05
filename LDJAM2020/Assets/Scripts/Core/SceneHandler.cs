using LudumDare.Core.EventManager;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LudumDare.Core
{
    public class SceneHandler : MonoBehaviour
    {
        private void Awake()
        {
            LoadScenes();
            //EventManager<Events>.RegisterEvent(Events.FailConditionMet, FailConditionMet);
        }

        //private void FailConditionMet(Events arg1, object[] arg2)
        //{
        //    SceneManager.LoadScene("EndScene");
        //}

        private void LoadScenes()
        {
            SceneManager.LoadScene("HUDScene", LoadSceneMode.Additive);
            SceneManager.LoadScene("MusicScene", LoadSceneMode.Additive);
        }

        //private void OnDestroy()
        //{
        //    EventManager<Events>.DeregisterEvent(Events.FailConditionMet, FailConditionMet);
        //}
    }
}