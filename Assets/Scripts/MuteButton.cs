using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;

public class MuteButton : MonoBehaviour
{
    public static MuteButton sharedInstance;

    public TextMeshProUGUI textMeshPro;
    public bool isMuted = false;

    public VideoPlayer videoPausa;
    public VideoPlayer videoGO;

    private void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;
    }


    private void Start()
    {
        textMeshPro.text = isMuted ? "Mute" : " ";
    }

    public void ToggleSound()
    {
        isMuted = !isMuted;

        textMeshPro.text = isMuted ? "Mute" : " ";
        videoPausa.SetDirectAudioMute(0, isMuted);
        videoGO.SetDirectAudioMute(0, isMuted);
        AudioManager.sharedInstance.BackgroundSoundOff();
        AudioManager.sharedInstance.JumpAudioOff();
        AudioManager.sharedInstance.CoinAudioOff();
        AudioManager.sharedInstance.GameOverAudioOff();
    }

}
