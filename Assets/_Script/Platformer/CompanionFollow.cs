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
    private Animator _animator;

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
        bool isMoving = distance > followDistance;

        _animator.SetBool("isMoving", isMoving);

        if (isMoving)
        {
            Vector2 direction = (player.position - transform.position).normalized;

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
            _rb.velocity = Vector2.zero;
        }
    }
}