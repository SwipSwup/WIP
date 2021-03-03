using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameplayInputEventChannelSO inputEventChannel;

    private void Start()
    {
        GetComponent<PlayerInput>().onActionTriggered += HandleInput;
    }

    private void OnDestroy()
    {
        GetComponent<PlayerInput>().onActionTriggered -= HandleInput;
    }

    private void HandleInput(InputAction.CallbackContext context)
    {
        //if (!context.performed) return;
        string actionName = context.action.name;
        //Debug.Log("performed " + context.performed);
        //Debug.Log("cancled " + context.canceled);
        //Debug.Log("started " + context.started);

        switch (actionName)
        {
            case "Movement":
                inputEventChannel.OnMovement(context);
                break;
            case "Jump":
                inputEventChannel.OnJump(context);
                break;
            case "Sprint":
                inputEventChannel.OnSprint(context);
                break;
            case "Croutch":
                inputEventChannel.OnCroutch(context);
                break;
            case "Action":
                inputEventChannel.OnAction(context);
                break;
            case "Interact":
                inputEventChannel.OnInteract(context);
                break;
            case "EquipItem":
                inputEventChannel.OnEquipItem(context);
                break;
            case "SwitchItem":
                inputEventChannel.OnSwitchItem(context);
                break;
            case "DropItem":
                inputEventChannel.OnDropItem(context);
                break;
        } 

    }
}
