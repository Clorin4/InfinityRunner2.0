using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager sharedInstance;

    public AudioSource backgroundAudioSource;
    public AudioSource JumpAudio;
    public AudioSource CoinAudio;
    public AudioSource GameOverAudio;

    public bool salto;

    private void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;
    }

    private void Start()
    {
        backgroundAudioSource.Play();
        salto = true;
    }

    public void BackgroundSoundOn()
    {
        backgroundAudioSource.Play();
    }

    public void JumpAudioOn()
    {
        JumpAudio.Play();
        salto = true;
    }

    public void CoinAudioOn()
    {
        CoinAudio.Play();
    }

    public void GameOverAudioOn()
    {
        GameOverAudio.Play();
    }

    //AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA

    public void BackgroundSoundOff()
    {
        //
        backgroundAudioSource.Pause();
    }

    public void JumpAudioOff()
    {
        JumpAudio.Pause();
        salto = false;
    }

    public void CoinAudioOff()
    {
        CoinAudio.Pause();
    }

    public void GameOverAudioOff()
    {
        GameOverAudio.Pause();
    }
}
