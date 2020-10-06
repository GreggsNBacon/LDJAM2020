using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LudumDare.Core;
using LudumDare.Model;
using UnityEngine.UI;
using TMPro;

public class EndLevelView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI lapCount;

    [SerializeField]
    private TextMeshProUGUI speed;

    [SerializeField]
    private TextMeshProUGUI cloneCount;

    private float mphPerUnit = 40.0f;
    private GameModel gameModel = null;
    private CarModel carModel = null;
    // Start is called before the first frame update
    void Start()
    {
        gameModel = Models.GetModel<GameModel>();
        carModel = Models.GetModel<CarModel>();
        mphPerUnit = carModel.mphPerUnit;

        UpdateLap();
        UpdateClones();
        UpdateSpeed();
    }
    private void UpdateLap()
    {
        lapCount.text = gameModel.lap.ToString();
    }

    private void UpdateClones()
    {
        cloneCount.text = (gameModel.lap - 1).ToString();
    }
    private void UpdateSpeed()
    {
        
        speed.text = (int)(carModel.maxAchievedSpeed * mphPerUnit) + " Mph";
    }
}
