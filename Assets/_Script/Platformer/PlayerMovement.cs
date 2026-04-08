using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private NewInput _newInput;

    public float speed;
    private Rigidbody2D _rb;

    void Awake()
    {
        PlayerStats.score = 0;
        _newInput = GetComponent<NewInput>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        _rb.velocity = _newInput.movement * speed;
    }
}