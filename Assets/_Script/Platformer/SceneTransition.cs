using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public float tiempoEspera = 7f; // duración de la cinemática

    void Start()
    {
        Invoke("LoadNextScene", tiempoEspera);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("Nivel2");
    }
}