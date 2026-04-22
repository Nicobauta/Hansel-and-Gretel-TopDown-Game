using UnityEngine;

public class Rock : MonoBehaviour
{
    public float damage = 5f;
    public float knockbackForce = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colision con: " + collision.gameObject.name);
        Debug.Log("Golpeé a: " + collision.gameObject.name);
        Debug.Log("Tag: " + collision.gameObject.tag);

        //  Si es muro (tilemap)
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            return;
        }

        //  Si es enemigo
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 dir = (collision.transform.position - transform.position).normalized;
                rb.AddForce(dir * knockbackForce, ForceMode2D.Impulse);
            }

            Destroy(gameObject);
        }
        else
        {
            //  Si es cualquier otra cosa, solo destruye la roca
            Destroy(gameObject);
        }
    }
}