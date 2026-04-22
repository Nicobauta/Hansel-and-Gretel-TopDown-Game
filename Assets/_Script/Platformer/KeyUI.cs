using UnityEngine;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour
{
    public Image keyIcon; 
    private PlayerStats player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerStats>();

        // Estado inicial: oscuro
        keyIcon.color = new Color(0f, 0f, 0f, 0.5f); // negro semi-transparente
    }

    void Update()
    {
        if (player.hasKey)
        {
            keyIcon.color = Color.white; // color original
        }
    }
}