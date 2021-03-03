using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameplayInputEventChannelSO inputEventChannel;

    [Space]
    [SerializeField] private new Camera camera;
    [SerializeField] private PlayerInput playerInput;

    [Space]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance = 1f;
    [SerializeField] private float groundCheckRadius = .75f;
    [SerializeField] private float gravity = 9.81f;

    [Space]
    [SerializeField] private float defaultSpeed = 100f;
    [SerializeField] private float sprintMult = 2f;
    [SerializeField] private float sneakMult = .5f;
    [SerializeField] private float slideMult = 2.5f;
    [SerializeField] private float slideDuration = 5f;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float jumpResistanceMultiplier = .5f;

    [Space]
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float mineDelay = 10f;

    private Vector2 moveDirection = Vector2.zero;
    private bool jump = false;
    private bool croutch = false;
    private bool sprint = false;
    private bool slide = false;

    private bool action = false;
    private bool interact = false;
    private bool dropItem = false;

    private int hotbarIndex = 0;

    private CharacterController cc;

    private void Start()
    {
        cc = GetComponent<CharacterController>();

        //Input
        inputEventChannel.movmentEvent += ReadDirectionValue;
        inputEventChannel.jumpEvent += Jump;
        inputEventChannel.sprintEvent += Sprint;
        inputEventChannel.croutchEvent += Croutch;
        inputEventChannel.actionEvent += Action;
        inputEventChannel.interactEvent += Interact;

    }

    private void OnDestroy()
    {
        //Input
        inputEventChannel.movmentEvent -= ReadDirectionValue;
    }

    private void Update()
    {
        MovePlayer();
    }

    #region Input
    private void Jump(InputAction.CallbackContext context) => jump = context.ReadValue<float>() == 1 ? true : false;
    private void Sprint(InputAction.CallbackContext context) => sprint = context.ReadValue<float>() == 1 ? true : false;
    private void Croutch(InputAction.CallbackContext context) => croutch = context.ReadValue<float>() == 1 ? true : false;
    private void Interact(InputAction.CallbackContext context)
    {
        if (context.performed) return;

        interact = context.ReadValue<float>() == 1 ? true : false;
    }

    private void Action(InputAction.CallbackContext context) => action = context.ReadValue<float>() == 1 ? true : false;
    #endregion

    #region movment
    private float verticalVelocity = 0f;
    private Vector3 jumpDirection = Vector3.zero;
    private float slideTime = 1f;
    private void MovePlayer()
    {
        Vector3 moveDirection = transform.forward * this.moveDirection.y + transform.right * this.moveDirection.x;

        if (isGrounded())
        {
            verticalVelocity = 0f;

            if (jump)
                verticalVelocity += jumpHeight;
        }
        else
        {
            jumpDirection = moveDirection;
            moveDirection = jumpDirection + (moveDirection - jumpDirection) * jumpResistanceMultiplier;
            verticalVelocity -= gravity * Time.deltaTime;
        }


        if (sprint && croutch)
        {
            //Temporary
            camera.transform.localPosition = new Vector3(0f, .3f, 0f);

            slide = true;
            slideTime += slideMult / slideDuration * Time.deltaTime;
            moveDirection *= Mathf.Clamp(slideMult - slideTime, 0, slideMult);

        }
        else
        {
            //Temporary
            camera.transform.localPosition = new Vector3(0f, .6f, 0f);

            slide = false;
            slideTime = 0f;
        }

        if (!slide)
        {
            if (sprint)
                moveDirection *= sprintMult;
            else if (croutch)
                moveDirection *= sneakMult;
        }

        cc.Move((moveDirection * defaultSpeed + Vector3.up * verticalVelocity) * Time.deltaTime);
    }

    private bool isGrounded()
    {
        Collider[] colliders = new Collider[2];
        Physics.OverlapSphereNonAlloc(groundCheck.position, .475f, colliders);

        foreach (Collider col in colliders)
            if (col.gameObject.tag != "Player") return true;

        return false;
    }

    public bool isMoving()
    {
        return moveDirection.magnitude > 0f;
    }

    private void ReadDirectionValue(InputAction.CallbackContext context) => moveDirection = context.ReadValue<Vector2>();
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 1f, 1f, .5f);
        Gizmos.DrawSphere(groundCheck.position, .475f);
    }
}
