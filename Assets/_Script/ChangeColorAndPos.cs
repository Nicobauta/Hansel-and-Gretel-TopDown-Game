using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorAndPos : MonoBehaviour
{
    public GameObject triangle;
    public SpriteRenderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = triangle.GetComponent<SpriteRenderer>();
        ChangeColor();
        ChangePos();
    }

    // Metodo para cambiar de color
    public void ChangeColor()
    {
        _renderer.color = Color.yellow;
    }

    public void ChangePos()
    {
        transform.position = triangle.transform.position;
    }
}
