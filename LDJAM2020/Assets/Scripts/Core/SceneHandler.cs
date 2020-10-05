using LudumDare.Core.EventManager;
using LudumDare.Model;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LudumDare.Core
{
    public class SceneHandler : MonoBehaviour
    {
        GameModel gameModel = null;
        private void Awake()
        {
            LoadScenes();
            //EventManager<Events>.RegisterEvent(Events.FailConditionMet, FailConditionMet);
        }

        private void Start()
        {
            gameModel = Models.GetModel<GameModel>();
            gameModel.level =  SceneManager.GetActiveScene().name;
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