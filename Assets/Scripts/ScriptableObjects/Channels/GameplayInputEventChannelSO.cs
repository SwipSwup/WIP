using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "GameplayInputEventChannelSO", menuName = "Event channel/Gameplay input event channel")]
public class GameplayInputEventChannelSO : ScriptableObject
{
    public Action<InputAction.CallbackContext> movmentEvent;
    public Action<InputAction.CallbackContext> jumpEvent;
    public Action<InputAction.CallbackContext> sprintEvent;
    public Action<InputAction.CallbackContext> croutchEvent;
    public Action<InputAction.CallbackContext> actionEvent;
    public Action<InputAction.CallbackContext> interactEvent;
    public Action<InputAction.CallbackContext> equipItemEvent;
    public Action<InputAction.CallbackContext> switchItemEvent;
    public Action<InputAction.CallbackContext> dropItemEvent;

    public void OnMovement(InputAction.CallbackContext context) => movmentEvent?.Invoke(context);
    public void OnJump(InputAction.CallbackContext context) => jumpEvent?.Invoke(context);
    public void OnSprint(InputAction.CallbackContext context) => sprintEvent?.Invoke(context);
    public void OnCroutch(InputAction.CallbackContext context) => croutchEvent?.Invoke(context);
    public void OnAction(InputAction.CallbackContext context) => actionEvent?.Invoke(context);
    public void OnInteract(InputAction.CallbackContext context) => interactEvent?.Invoke(context);
    public void OnEquipItem(InputAction.CallbackContext context) => equipItemEvent?.Invoke(context);
    public void OnSwitchItem(InputAction.CallbackContext context) => switchItemEvent?.Invoke(context);
    public void OnDropItem(InputAction.CallbackContext context) => dropItemEvent?.Invoke(context);
}
