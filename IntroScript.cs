using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    public AudioSource Sfxaud;
    public AudioClip panic, explosion;

    public void panicSound()
    {
        Sfxaud.PlayOneShot(panic);
    }

    public void ExploSound()
    {
        Sfxaud.PlayOneShot(explosion);
    }
    public void EndIntro()
    {
        SceneManager.LoadScene(2);
    }
}
