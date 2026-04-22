using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float healAmount = 10f; //  valor fijo
    public int scoreValue = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats stats = collision.GetComponent<PlayerStats>();

            if (stats != null)
            {
                // Curar
                if (stats.vida < stats.vidaMax)
                {
                    stats.Heal(healAmount);
                }

                // Score
                stats.AddScore(scoreValue);
            }

            Destroy(gameObject);
        }
    }
}