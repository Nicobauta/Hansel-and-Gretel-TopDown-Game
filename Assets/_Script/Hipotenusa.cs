using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hipotenusa : MonoBehaviour
{
    //Creacion de variabels
    [Header("Numbers")]
    public int c;
    public int d;
    private float _result;

    // Start is called before the first frame update
    void Start()
    {
        CalHipotenusa();
    }

    // Metodo para la hipotenusa
    public void CalHipotenusa()
    {

        _result = Mathf.Sqrt(Mathf.Pow(c, 2) + Mathf.Pow(d, 2));
        Debug.Log("El resultado de la hipotenusa es: " + _result);
    }
}
