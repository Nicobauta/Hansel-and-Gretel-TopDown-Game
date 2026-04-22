using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class CompanionFollow : MonoBehaviour
{
    [Header("Target")]
    public Transform player;

    [Header("Movement")]
    public float speed = 2f;
    public float followDistance = 0.3f;

    private Rigidbody2D _rb;
    private Animator _animator;
    private Vector2 _lastDirection = new Vector2(0, -1);

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        bool isMoving = false; // Empezamos asumiendo que está quieto

        // Solo se mueve si está lejos del jugador
        // Le damos un pequeño margen extra (+ 0.05f) para evitar que titile intentando llegar a la distancia exacta
        if (distance > followDistance + 0.05f)
        {
            Vector2 rawDirection = (player.position - transform.position).normalized;

            if (Mathf.Abs(rawDirection.x) > Mathf.Abs(rawDirection.y))
            {
                _lastDirection = new Vector2(Mathf.Sign(rawDirection.x), 0);
            }
            else
            {
                _lastDirection = new Vector2(0, Mathf.Sign(rawDirection.y));
            }

            Vector2 targetPosition = (Vector2)player.position - rawDirection * followDistance;

            _rb.MovePosition(Vector2.MoveTowards(
                transform.position,
                targetPosition,
                speed * Time.fixedDeltaTime
            ));

            isMoving = true; // Confirmamos que se está moviendo físicamente
        }
        else
        {
            // Se queda quieto
            _rb.velocity = Vector2.zero;
        }

        // Enviamos siempre el estado final al Animator
        _animator.SetBool("isMoving", isMoving);
        _animator.SetFloat("moveX", _lastDirection.x);
        _animator.SetFloat("moveY", _lastDirection.y);
    }
}