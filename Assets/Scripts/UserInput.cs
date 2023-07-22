using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static UserInput instance;
    PlayerInput playerInput;
    InputAction jumpAction, attackAction, dashAction, menuOpenCloseAction, moveAction;


    public Vector2 moveInput { get; private set; }
    public bool jumpJustPressed { get; private set; }
    public bool jumpBeingHeld { get; private set; }
    public bool jumpReleased { get; private set; }
    public bool attackInput { get; private set; }
    public bool dashInput { get; private set; }
    public bool menuOpenCloseInput { get; private set; }


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        playerInput= GetComponent<PlayerInput>();
        SetupInputActions();
    }
    private void Update()
    {
        UpdateInputs();
    }
    private void SetupInputActions()
    {
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        attackAction = playerInput.actions["Attack"];
        dashAction = playerInput.actions["Dash"];
     //   menuOpenCloseAction = playerInput.actions["MenuOpenClose"];
    }
    private void UpdateInputs()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        jumpJustPressed = jumpAction.WasPressedThisFrame();
        jumpBeingHeld = jumpAction.IsPressed();
        jumpJustPressed = jumpAction.WasReleasedThisFrame();
        attackInput = attackAction.WasPressedThisFrame();
        dashInput = dashAction.WasPressedThisFrame();
     //   menuOpenCloseInput = menuOpenCloseAction.WasPressedThisFrame();
    }
}
