using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private NewInput _newInput;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _newInput = GetComponent<NewInput>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveAnim();
    }

    public void PlayerMoveAnim()
    {
        Vector2 move = _newInput.movement;

        _animator.SetBool("isMoving", move != Vector2.zero);

        _animator.SetFloat("moveX", move.x);
        _animator.SetFloat("moveY", move.y);
    }
}
