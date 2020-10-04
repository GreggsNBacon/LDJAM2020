using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LudumDare.Core;
using LudumDare.Model;
public class PlayerSettingUpdater : MonoBehaviour
{
    private GameModel gameModel = null;
    private CarModel carModel = null;

    [SerializeField]
    private float speedIncrease = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameModel = Models.GetModel<GameModel>();
        carModel = Models.GetModel<CarModel>();

        gameModel.OnLapUpdated += LapUpdated;
    }

    private void LapUpdated(int lap)
    {
        if(carModel.currentSpeed < carModel.maxSpeed)
        {
            carModel.currentSpeed += speedIncrease;
        }
    }

    private void OnDestroy()
    {
        gameModel.OnLapUpdated -= LapUpdated;
    }
}
