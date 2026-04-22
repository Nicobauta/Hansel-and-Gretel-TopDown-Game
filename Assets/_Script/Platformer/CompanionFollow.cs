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

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        // Solo se mueve si está lejos del jugador
        if (distance > followDistance)
        {
            Vector2 direction = (player.position - transform.position).normalized;

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