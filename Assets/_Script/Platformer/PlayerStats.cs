using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float vidaMax = 100f;
    public float vida;

    public int rocas = 5;
    public int score;
    public bool hasKey = false;

    void Start()
    {
        vida = vidaMax;
        score = 0; //  FORZAR inicio en 0
    }

    public void TakeDamage(float damage)
    {
        vida -= damage;

        if (vida <= 0)
        {
            vida = 0;
            Die();
        }
    }

    public void Heal(float amount)
    {
        vida += amount;

        if (vida > vidaMax)
            vida = vidaMax;
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }

    void Die()
    {
        Debug.Log("Jugador muerto");
    }
}