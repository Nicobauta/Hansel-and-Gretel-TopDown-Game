using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionFollow : MonoBehaviour
{
    [Header("Target")]
    public Transform player;

    [Header("Movement")]
    public float speed = 2f;
    public float followDistance = 0.3f;

    private Rigidbody2D _rb;
<<<<<<< HEAD
    private Animator _animator; // Referencia al Animator
=======
    private Animator _animator;
    private bool hasAnimator;
>>>>>>> 9d1dd015bd8d3d49b4682fe3fb0ac24db5e07130

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
<<<<<<< HEAD
        _animator = GetComponent<Animator>(); // Obtenemos el Animator
=======

        _animator = GetComponent<Animator>();
        hasAnimator = _animator != null;
>>>>>>> 9d1dd015bd8d3d49b4682fe3fb0ac24db5e07130
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        
        // Determinamos si se está moviendo (si está más lejos de la distancia mínima)
        bool isMoving = distance > followDistance;

        // Le pasamos el estado al Animator
        _animator.SetBool("isMoving", isMoving);

<<<<<<< HEAD
        // Solo se mueve si está lejos del jugador
=======
        bool isMoving = distance > followDistance;

        if (hasAnimator)
        {
            _animator.SetBool("isMoving", isMoving);
        }
>>>>>>> 9d1dd015bd8d3d49b4682fe3fb0ac24db5e07130

        if (isMoving)
        {
            Vector2 direction = (player.position - transform.position).normalized;

<<<<<<< HEAD
<<<<<<< HEAD
            // Actualizamos la dirección en el Animator solo cuando se mueve
            // Esto asegura que recuerde su última posición (espalda, frente, etc) al detenerse
            _animator.SetFloat("moveX", direction.x);
            _animator.SetFloat("moveY", direction.y);
=======
            // Actualizamos animación solo si existe
=======
>>>>>>> 92266fc2bd3e5b997902f4d3f97d7802b16b1bdd
            if (hasAnimator)
            {
                _animator.SetFloat("moveX", direction.x);
                _animator.SetFloat("moveY", direction.y);
            }
>>>>>>> 9d1dd015bd8d3d49b4682fe3fb0ac24db5e07130

            Vector2 targetPosition = (Vector2)player.position - direction * followDistance;

            _rb.MovePosition(Vector2.MoveTowards(
                transform.position,
                targetPosition,
                speed * Time.fixedDeltaTime
            ));
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }
    }
}