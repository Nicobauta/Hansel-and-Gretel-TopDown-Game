using System.Collections;
using UnityEngine;

public class PlayerHealth2 : MonoBehaviour
{
    public int maxHealth;
    private Animator animator;

    void Start()
    {
        // Inicializar SOLO si no existe (persistencia entre escenas)
        if (PlayerStats2.vidaMax == 0)
        {
            PlayerStats2.vidaMax = maxHealth;
            PlayerStats2.vida = maxHealth;
        }

        animator = GetComponent<Animator>();
    }

    IEnumerator WaitForDamage()
    {
        Physics2D.IgnoreLayerCollision(3, 6, true);

        animator.SetBool("isHit", true);

        PlayerStats2.vida--;

        yield return new WaitForSeconds(1.1f);

        animator.SetBool("isHit", false);

        Physics2D.IgnoreLayerCollision(3, 6, false);
    }

    public void GetDamage()
    {
        if (PlayerStats2.vida > 1)
        {
            StartCoroutine(WaitForDamage());
        }
        else
        {
            PlayerStats2.vida = 0;
            Destroy(gameObject);
        }
    }
}