using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StopMovingCondition", menuName = "StateMachine/Conditions/Test")]
public class TestCondition : StateCondition
{

    public override void Active(StateMachine stateMachine)
    {
    }

    public override bool Statement()
    {
        return false;
    }
}
