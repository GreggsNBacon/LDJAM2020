using LudumDare.Core;
using LudumDare.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuickRestart : MonoBehaviour
{
    GameModel model;

    MainInput input;
    private void Start()
    {
        model = Models.GetModel<GameModel>();
        input = new MainInput();
        input.Car.Restart.performed += x => Restart();
        input.Car.Restart.Enable();
    }

    private void Restart()
    {
        SceneManager.LoadScene(model.level);
    }


}
