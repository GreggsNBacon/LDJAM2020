using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    List<ITransition> transitions { get; set; }
    void Enter();
    void Update();
    void Exit();
    void OnDestroy();
}
