using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettingsInGame : MonoBehaviour
{

    public AudioSource Maud,Saud;
    // Start is called before the first frame update
    void Start()
    {
        Maud.volume = PlayerPrefs.GetFloat("MUSIC");
        Saud.volume = PlayerPrefs.GetFloat("SFX");
    }

}
