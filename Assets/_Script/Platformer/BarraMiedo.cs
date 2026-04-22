using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BarraMiedo : MonoBehaviour
{
    public Image rellenoBarraMiedo;
    private PlayerStats playerStats;
    private float vidaMaxima;

    void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        vidaMaxima = playerStats.vidaMax;
    }

    void Update()
    {
        rellenoBarraMiedo.fillAmount = playerStats.vida / vidaMaxima;
    }
}