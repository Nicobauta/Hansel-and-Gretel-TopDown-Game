using UnityEngine;

public class RockPickup : MonoBehaviour
{
    public int amount = 3; // cantidad de rocas que da

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats stats = collision.GetComponent<PlayerStats>();

            if (stats != null)
            {
                stats.rocas += amount;
                Debug.Log("Rocas actuales: " + stats.rocas);
            }

            Destroy(gameObject);
        }
    }
}