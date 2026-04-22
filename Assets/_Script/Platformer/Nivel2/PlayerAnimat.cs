using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Requerido para leer el PlayerInput directamente

[RequireComponent(typeof(Animator), typeof(NewInput), typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
public class PlayerAnimat : MonoBehaviour
{
    private Animator _animator;
    private NewInput _input;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    
    // Nueva variable para leer la acción del teclado/control
    private PlayerInput _playerInput; 
    
    // Awake es ideal para inicializar referencias a componentes críticos antes del Start
    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _input = GetComponent<NewInput>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoving();
        Flip();
        PlayerJumping();
    }

    public void PlayerMoving()
    {
        _animator.SetBool("isMoving", _input.movement.x != 0);
    }

    public void PlayerJumping()
    {
        // Detecta el frame exacto en el que el jugador presiona el botón configurado como "Jump" (Espacio)
        if (_playerInput.actions["Jump"].WasPressedThisFrame())
        {
            // Dispara la animación de salto desde Any State. 
            // Nota: Crea un parámetro tipo "Trigger" en tu Animator llamado "JumpTrigger".
            _animator.SetTrigger("JumpTrigger");
        }

        // Puedes conservar tu variable Float por si la necesitas para volver a Idle cuando toque el suelo
        _animator.SetFloat("isJumping", Mathf.Abs(_rigidbody.velocity.y));
    }

    public void Flip()
    {
        if(_input.movement.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_input.movement.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
