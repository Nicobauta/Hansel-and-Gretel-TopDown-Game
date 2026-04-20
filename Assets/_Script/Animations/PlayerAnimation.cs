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
        bool isMoving = move != Vector2.zero;

        _animator.SetBool("isMoving", isMoving);

        // Only update the direction floats if we are actually moving.
        // This ensures the Animator remembers the last faced direction when stopping.
        if (isMoving)
        {
            _animator.SetFloat("moveX", move.x);
            _animator.SetFloat("moveY", move.y);
        }
    }
}
