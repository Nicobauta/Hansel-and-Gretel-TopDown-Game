using UnityEngine;
using UnityEngine.InputSystem;

public class NewInput2 : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;

    [HideInInspector] public float inputX;
    [HideInInspector] public float inputY;

    private PlayerJump2 _playerJump;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];

        _playerJump = GetComponent<PlayerJump2>();
    }

    private void Update()
    {
        GetInput();
        HandleJump();
    }

    public void GetInput()
    {
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();

        inputX = input.x;
        inputY = input.y;
    }

    void HandleJump()
    {
        if (jumpAction.triggered)
        {
            _playerJump.Jump();
        }
    }
}