using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "State", menuName = "StateMachine/State")]
public class State : ScriptableObject
{
    [SerializeField] private string state;
    [SerializeField] private StateTransition[] transitions;

    public bool OnTransition(out State newState, StateMachine stateMachine)
    {
        foreach(StateTransition transition in transitions)
        {
            if(transition.Transit(stateMachine))
            {
                Debug.Log(state + ": " + transition.transitionState);
                newState = transition.transitionState;
                return true;
            }
        }

        newState = null;
        return false;
    }
}
