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
    private Animator _animator; // Referencia al Animator

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>(); // Obtenemos el Animator
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
        
        // Solo se mueve si está lejos del jugador

        if (isMoving)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            // Actualizamos la dirección en el Animator solo cuando se mueve
            // Esto asegura que recuerde su última posición (espalda, frente, etc) al detenerse
            _animator.SetFloat("moveX", direction.x);
            _animator.SetFloat("moveY", direction.y);
            

            Vector2 targetPosition = (Vector2)player.position - direction * followDistance;

            _rb.MovePosition(Vector2.MoveTowards(
                transform.position,
                targetPosition,
                speed * Time.fixedDeltaTime
            ));
        }
        else
        {
            // Se queda quieto
            _rb.velocity = Vector2.zero;
        }
    }
}