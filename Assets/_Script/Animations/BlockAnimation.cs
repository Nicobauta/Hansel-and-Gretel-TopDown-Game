using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAnimation : MonoBehaviour
{
    public Animator _anim;

    private void OnTriggerEnter2D(Collider2D Collider)
    {
       if (Collider.CompareTag("Player"))
        {
            _anim.SetTrigger("Anim");
        }
    }

}
