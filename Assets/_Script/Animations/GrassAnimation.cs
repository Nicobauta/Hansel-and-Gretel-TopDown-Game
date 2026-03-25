using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassAnimation : MonoBehaviour
{
    public Animator _anim;

    // Update is called once per frame
    void Update()
    {
        GrassAnim();
    }

    public void GrassAnim()
    {
        if(Input.GetKeyDown(KeyCode.G))
            _anim.SetTrigger("Anim");
    }
}
