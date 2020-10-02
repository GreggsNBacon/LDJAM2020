using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericStateMachine
{
    private IState currentState;
    public GenericStateMachine()
    {
        currentState = null;
    }

    ~GenericStateMachine()
    {
        if(currentState != null)
        {
            currentState.OnDestroy();
        }
    }

    public void Initialize(IState initialState)
    {
        Transition(initialState);
    }

    public IState GetCurrentState()
    {
        return currentState;
    }

    public void Update()
    {
        if (currentState != null)
        {
            for (int i = 0; i < currentState.transitions.Count; i++)
            {
                if (currentState.transitions[i].EvaluateCondition())
                {
                    Transition(currentState.transitions[i].GetNextState());
                    break;
                }
            }
            currentState.Update();
        }
    }

    private void Transition(IState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        if (currentState != null)
        {
            currentState.Enter();
        }
    }

}
