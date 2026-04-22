using UnityEngine;

public class Rock2 : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;
    public float damage = 2f;

    private Rigidbody2D rb;

    public void Init(Vector2 direction)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;

        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>()?.TakeDamage(damage);

            Rigidbody2D enemyRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (enemyRb != null)
            {
                Vector2 push = (collision.transform.position - transform.position).normalized;
                enemyRb.AddForce(push * 5f, ForceMode2D.Impulse);
            }
        }

        Destroy(gameObject);
    }
}