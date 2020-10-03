using LudumDare.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LudumDare.Model.GameModel;

public class FollowTest : MonoBehaviour
{
    [SerializeField]
    private float delayTime = 5.0f;
    private GameModel gameModel = null;
    private PositionalData posData = null;
    private bool delay = true;
    // Start is called before the first frame update
    void Start()
    {
        gameModel = LudumDare.Core.Models.GetModel<GameModel>();
        posData = gameModel.first;
        StartCoroutine(SetDelay());
    }
    IEnumerator SetDelay()
    {
        yield return new WaitForSeconds(delayTime);
        delay = false;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (delay)
        {
            return;
        }
        if(posData == null)
        {
            posData = gameModel.first;
        }
        else
        {
            transform.position = posData.Position;
            transform.rotation = Quaternion.Euler(posData.Rotation);
            posData = posData.next;
        }
        
    }
}
