using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance = null;

    public AudioSource music;
    public AudioSource jumpAudio;
    public AudioSource deathAudio;
    public AudioSource buttonPressAudio;

    public void PlayJumpSound()
    {
        jumpAudio.Play();
    }

    public void PlayDeathSound()
    {
        deathAudio.Play();
    }

    public void PlayButtonPressSound()
    {
        buttonPressAudio.Play();
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
}
