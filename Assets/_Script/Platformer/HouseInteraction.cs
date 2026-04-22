using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseInteraction : MonoBehaviour
{
    private bool playerInRange = false;
    private PlayerStats player;


    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            TryEnterHouse();
        }
    }

    void TryEnterHouse()
    {
        if (player != null && player.hasKey)
        {
            Debug.Log("Entrando a la casa...");
            SceneManager.LoadScene("TransicionNivel1");
        }
        else
        {
            Debug.Log("Necesitas una llave");
        }
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