using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateCondition : ScriptableObject
{
    public abstract bool Statement();
    public abstract void Active(StateMachine stateMachine);
}
