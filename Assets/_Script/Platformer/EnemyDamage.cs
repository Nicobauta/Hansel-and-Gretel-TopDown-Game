using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage = 10f;
    public float damageCooldown = 1f;

    private float lastHitTime;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time >= lastHitTime + damageCooldown)
            {
                PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();

                if (player != null)
                {
                    player.TakeDamage(damage);
                    lastHitTime = Time.time;
                }
            }
        }
    }
}