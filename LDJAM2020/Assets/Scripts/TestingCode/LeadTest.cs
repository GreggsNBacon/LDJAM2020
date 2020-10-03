using LudumDare.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadTest : MonoBehaviour
{
    private GameModel gameModel = null;
    // Start is called before the first frame update
    void Start()
    {
        gameModel = LudumDare.Core.Models.GetModel<GameModel>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameModel == null)
        {
            gameModel = LudumDare.Core.Models.GetModel<GameModel>();
        }
        gameModel.AddToList(transform.position, transform.rotation.eulerAngles);
    }
}
