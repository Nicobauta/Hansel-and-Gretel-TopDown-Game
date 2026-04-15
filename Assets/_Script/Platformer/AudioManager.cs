using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource bgAudioSource;
    public AudioSource sfxAudioSource;

    public AudioClip jump;
    public AudioClip pick;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayJump()
    {
        PlaySound(jump);
    }

    public void PlayPick()
    {
        PlaySound(pick);
    }

    private void PlaySound(AudioClip clip)
    {
        sfxAudioSource.PlayOneShot(clip);
    }
    

}
