using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{

    public Slider MusicVolume, SFXVolume;
    public AudioSource aud;
    private void Start()
    {
        if (PlayerPrefs.GetFloat("MUSIC") == 0)
        {
            PlayerPrefs.SetFloat("MUSIC", 0.5f);
        }
        if (PlayerPrefs.GetFloat("SFX") == 0)
        {
            PlayerPrefs.SetFloat("SFX", 0.5f);
        }
        MusicVolume.value = PlayerPrefs.GetFloat("MUSIC");
        SFXVolume.value = PlayerPrefs.GetFloat("SFX");
    }

    void FixedUpdate()
    {
        PlayerPrefs.SetFloat("MUSIC", MusicVolume.value);
        PlayerPrefs.SetFloat("SFX", SFXVolume.value);
        aud.volume = PlayerPrefs.GetFloat("MUSIC");
    }
}
