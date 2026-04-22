using UnityEngine;
using TMPro;

public class RocasUI : MonoBehaviour
{
    public TextMeshProUGUI textoRocas;
    public PlayerStats player;

    void Update()
    {
        textoRocas.text = "x " + player.rocas;
    }
}