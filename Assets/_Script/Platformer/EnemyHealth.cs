using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float vida = 15f;
    public int scoreValue = 40;

    void Start()
    {
        Debug.Log("Vida inicial enemigo: " + vida);
    }

    public void TakeDamage(float damage)
    {
        vida -= damage;

        Debug.Log("Vida enemigo: " + vida);

        if (vida <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Se murio AL INICIAR?");
        PlayerStats player = FindObjectOfType<PlayerStats>();

        if (player != null)
        {
            player.AddScore(scoreValue);
        }

        Debug.Log("Se murio");
        Destroy(gameObject);
    }
}