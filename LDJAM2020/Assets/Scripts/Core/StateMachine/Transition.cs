using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ITransition
{
    bool EvaluateCondition();
    IState GetNextState();
}

public class Transition : ITransition
{
    private IState nextState;
    private Func<bool> condition;

    public IState GetNextState()
    {
        return nextState;
    }

    public bool EvaluateCondition()
    {
        return condition();
    }

    public Transition(IState state, Func<bool> newCondition)
    {
        nextState = state;
        condition = newCondition;
    }
}
