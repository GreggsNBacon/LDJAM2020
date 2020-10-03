using LudumDare.Core;
using LudumDare.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererScripting : MonoBehaviour
{
    [SerializeField]
    LineRenderer line;
    private GameModel gameModel = null;

    // Start is called before the first frame update
    void Start()
    {
        gameModel = Models.GetModel<GameModel>();

        gameModel.OnPositionUpdated += PositionUpdated;

    }
    private void PositionUpdated(Vector3 pos)
    {
        line.positionCount = line.positionCount + 1;
        line.SetPosition(line.positionCount - 1, pos);
    }
     void OnDestroy()
    {
        gameModel.OnPositionUpdated -= PositionUpdated;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
