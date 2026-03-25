using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise : MonoBehaviour
{
    //Creacion de variabels
    [Header("Numbers")]
    public int a;
    public int b;
    private int _result;

    // Start is called before the first frame update
    void Start()
    {
        AddNumber();
    }

    //Metodo para la suma
    public void AddNumber()
    {
        _result = a + b;
        Debug.Log("El resultado es: " + _result);
        Debug.Log(string.Format("El resultado de sumar {0} y {1} es: {2}", a, b, _result));
    }

    
}
