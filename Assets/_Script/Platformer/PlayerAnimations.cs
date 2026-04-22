using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(NewInput), typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
    private NewInput _input;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    
    // Start is called before the first frame update
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
        PlayerJumping();
    }

    public void PlayerMoving()
    {
        // 1. Revisa si hay movimiento
        bool isMoving = _input.movement.sqrMagnitude > 0;
        _animator.SetBool("isMoving", isMoving);

        // 2. Envía la dirección (X y Y)
        _animator.SetFloat("moveX", _input.lastDirection.x);
        _animator.SetFloat("moveY", _input.lastDirection.y);
    }

    public void PlayerJumping()
    {
        // Si hay una velocidad en Y (positiva al subir o negativa al caer) mayor a 0.1, está en el aire 
        bool isJumping = Mathf.Abs(_rigidbody.velocity.y) > 0.1f;
        
        // Enviamos esto como un Bool a tu Animator (Asegúrate de cambiar "isJumping" a Bool en tu Animator)
        _animator.SetBool("isJumping", isJumping);
    }
}
