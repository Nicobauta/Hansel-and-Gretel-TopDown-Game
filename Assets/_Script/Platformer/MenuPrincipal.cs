using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void NuevoJuego()
    {
        SceneManager.LoadScene("TransicionMenu");
    }
    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}