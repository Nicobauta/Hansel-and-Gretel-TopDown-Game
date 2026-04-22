using UnityEngine;
using TMPro;

public class UI_Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public PlayerStats player;

    void Update()
    {
        scoreText.text = "Score: " + player.score;
    }
}