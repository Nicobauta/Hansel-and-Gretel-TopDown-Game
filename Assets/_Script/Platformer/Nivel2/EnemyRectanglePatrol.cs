using UnityEngine;

public class EnemyRectanglePatrol : MonoBehaviour
{
    public Transform[] points; // A, B, C, D
    public float speed = 10f;

    private int currentPoint = 0;

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (points.Length == 0) return;

        Transform target = points[currentPoint];

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            currentPoint++;

            if (currentPoint >= points.Length)
            {
                currentPoint = 0; // loop
            }
        }
    }
}