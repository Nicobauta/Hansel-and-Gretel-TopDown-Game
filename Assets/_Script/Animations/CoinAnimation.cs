using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    public Animator _anim;
    

    // Update is called once per frame
    void Update()
    {
        CoinAnim();
    }

    public void CoinAnim()
    {
        if(Input.GetKeyDown(KeyCode.R))
            _anim.SetTrigger("Anim");
    }
}
