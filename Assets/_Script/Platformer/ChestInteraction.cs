using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    private bool playerInRange = false;
    private bool opened = false;

    public GameObject openChestSprite; // opcional si cambias visual
    private PlayerStats player;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !opened)
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        opened = true;

        if (player != null)
        {
            player.hasKey = true;
            Debug.Log("Llave obtenida");
        }

        // Cambiar sprite (opcional)
        if (openChestSprite != null)
        {
            openChestSprite.SetActive(true);
        }

        // Opcional: destruir cofre
        // Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            player = collision.GetComponent<PlayerStats>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}