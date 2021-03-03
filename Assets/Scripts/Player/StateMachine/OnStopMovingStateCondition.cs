using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StopMovingCondition", menuName = "StateMachine/Conditions/StopMoving")]
public class OnStopMovingStateCondition : StateCondition
{
    private PlayerController controller;

    public override void Active(StateMachine stateMachine)
    {
        controller = stateMachine.GetComponent<PlayerController>();
    }

    public override bool Statement()
    {
        return !controller.isMoving();
    }
}
