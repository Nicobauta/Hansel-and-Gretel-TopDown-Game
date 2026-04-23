using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

[RequireComponent(typeof(Animator), typeof(NewInput), typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
public class PlayerAnimat : MonoBehaviour
{
    private Animator _animator;
    private NewInput _input;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private PlayerInput _playerInput; 
    
    private Collider2D _collider;

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
        _collider = GetComponent<Collider2D>();
    }

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
        // 1. Iniciamos el rayo desde la parte más BAJA del personaje, no desde el centro
        Vector2 checkPosition = new Vector2(_collider.bounds.center.x, _collider.bounds.min.y);
        float checkDistance = 0.1f;
        
        // 2. Usamos RaycastAll para obtener todo lo que tocamos
        RaycastHit2D[] hits = Physics2D.RaycastAll(checkPosition, Vector2.down, checkDistance);

        bool isJump = true; // Por defecto asumimos que estamos en el aire

        // 3. Revisamos todo lo que tocó el rayo
        foreach (RaycastHit2D hit in hits)
        {
            // Si tocamos algo que NO sea nuestro propio collider, significa que pisamos suelo
            if (hit.collider != null && hit.collider != _collider && !hit.collider.isTrigger)
            {
                isJump = false; // Tocamos el suelo
                break;
            }
        }

        // 4. Enviamos el valor booleano a tu parámetro "isjumping"
        _animator.SetBool("isjumping", isJump);
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
