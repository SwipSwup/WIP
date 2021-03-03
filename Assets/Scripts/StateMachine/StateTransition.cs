using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StateTransition", menuName = "StateMachine/Transition")]
public class StateTransition : ScriptableObject
{
    [SerializeField] private Condition[] conditions;
    [SerializeField] public State transitionState;

    public bool Transit(StateMachine stateMachine)
    {
        bool transit = false;

        foreach(Condition condition in conditions)
        {
            condition.condition.Active(stateMachine);
            
            if(condition.and && !condition.condition.Statement()) return false;
            transit = condition.condition.Statement();
        }
        return transit;
    } 

    [System.Serializable]
    class Condition
    {
        public StateCondition condition;
        public bool and;
    }
}