using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nota5 : MonoBehaviour
{
    public GameObject circle;
    public SpriteRenderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = circle.GetComponent<SpriteRenderer>();
        ChangeColor();
        ChangePos();
      
    }

    // Metodo para cambiar de color
    public void ChangeColor()
    {

        _renderer.color = Color.green;
    }

    public void ChangePos()
    {
        Vector3 hexagonPosition = transform.position;
        circle.transform.position = hexagonPosition;
        Debug.Log("Funciona: ");
        Debug.Log("La posicion del circulo es: " + hexagonPosition + " y su color es: " + _renderer.color);

    }

 

}
