using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StateCondition", menuName = "StateMachine/Conditions/IsMoving")]
public class OnStartpMovingStateCondition : StateCondition
{
    private PlayerController controller;

    public override bool Statement()
    {
        return controller.isMoving();
    }

    public override void Active(StateMachine stateMachine)
    {
        controller = stateMachine.GetComponent<PlayerController>();
    }
}
