
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInput : MonoBehaviour
{
    // Se declaran las variables
    private PlayerInput playerInput;
    [HideInInspector] public Vector2 movement;

    private PlayerJump _playerJump;

    // Al inicio de juego
    private void Start()
    {
        // Se almacena en la variable el componente acorde de Unity
        playerInput = GetComponent<PlayerInput>();
        _playerJump = GetComponent<PlayerJump>();
    }

    // Cada frame
    private void Update()
    {
        // Se llama al m�todo para que funcione
        GetInput();
    }

    public void JumpAction(InputAction.CallbackContext context)
    {
        // Tres momentos: cuando se presiona, cuando se est� presionando y cuando se deja de presionar
        if (context.started)
        {
            _playerJump.Jump();
        }
    }

  
    public void GetInput()
    {
        movement = playerInput.actions["Move"].ReadValue<Vector2>();
    }
}
