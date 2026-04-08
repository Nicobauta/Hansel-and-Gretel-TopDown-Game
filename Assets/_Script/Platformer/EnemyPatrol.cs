using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    public Transform pointA;
    public Transform pointB;

    [Header("Movement")]
    public float patrolSpeed = 2f;
    public float chaseSpeed = 3.5f;

    private Transform target;

    [Header("Player Detection")]
    public Transform player;
    public float detectionRadius = 5f;

    private void Awake()
    {
        target = pointA;
    }

    private void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    //  Patrulla entre A y B
    void Patrol()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            patrolSpeed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }

    //  Perseguir al jugador (top-down completo)
    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            chaseSpeed * Time.deltaTime
        );
    }

    //  Visualizar el rango de detección en Unity
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}