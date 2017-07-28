using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {
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
}
