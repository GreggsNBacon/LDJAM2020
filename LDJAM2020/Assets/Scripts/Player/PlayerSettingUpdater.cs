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

    [SerializeField]
    private float increaseRate = 1.0f;

    private float desiredSpeed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameModel = Models.GetModel<GameModel>();
        carModel = Models.GetModel<CarModel>();

        gameModel.OnLapUpdated += LapUpdated;
        desiredSpeed = carModel.minSpeed;
    }

    private void LapUpdated(int lap)
    {
        if(carModel.currentSpeed < carModel.maxSpeed)
        {
            desiredSpeed += speedIncrease;
        }
    }

    private void Update()
    {
        if (carModel != null && carModel.currentSpeed < carModel.maxSpeed && carModel.currentSpeed < desiredSpeed )
        {
            carModel.currentSpeed += Time.deltaTime * increaseRate;
        }
    }

    private void OnDestroy()
    {
        gameModel.OnLapUpdated -= LapUpdated;
    }
}
