using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimat : MonoBehaviour
{
    private Animator _animator;
    
    // Guardamos la última posición para saber cuánto y hacia dónde se movió
    private Vector2 _lastPosition;
    
    // Dirección por defecto (mirando hacia abajo)
    private Vector2 _lastDirection = new Vector2(0, -1);

    void Start()
    {
        _animator = GetComponent<Animator>();
        _lastPosition = transform.position;
    }

    void Update()
    {
        Vector2 currentPosition = transform.position;
        
        // Calculamos cuánto se movió desde el frame anterior
        Vector2 movement = currentPosition - _lastPosition;

        // Comprobamos si hay movimiento real
        bool isMoving = movement.sqrMagnitude > 0.00001f;

        if (isMoving)
        {
            Vector2 rawDirection = movement.normalized;

            // Decidimos la dirección (X o Y) para el blend tree basándonos en 
            // qué eje tuvo el mayor desplazamiento. Especialmente útil 
            // cuando persigue en diagonal al jugador.
            if (Mathf.Abs(rawDirection.x) > Mathf.Abs(rawDirection.y))
            {
                _lastDirection = new Vector2(Mathf.Sign(rawDirection.x), 0);
            }
            else
            {
                _lastDirection = new Vector2(0, Mathf.Sign(rawDirection.y));
            }
        }

        // Enviamos siempre el estado de movimiento real (si está patrullando o persiguiendo será true, si lo detienes será false)
        _animator.SetBool("isMoving", isMoving);
        
        // Enviamos la última dirección en la que fue visto moviéndose
        _animator.SetFloat("moveX", _lastDirection.x);
        _animator.SetFloat("moveY", _lastDirection.y);

        _lastPosition = currentPosition;
    }
}
