using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseOBJ;
    public AudioSource MusicVolume, SFXVolume;
    public Slider MusicSlider, SFXSlider;
    // Start is called before the first frame update


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
        MusicSlider.value = PlayerPrefs.GetFloat("MUSIC");
        SFXSlider.value = PlayerPrefs.GetFloat("SFX");
    }
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!PauseOBJ.activeInHierarchy)
            {
                PauseOBJ.SetActive(true);
            }
        }
        if (PlayerPrefs.GetFloat("MUSIC") == 0)
        {
            PlayerPrefs.SetFloat("MUSIC", 0.5f);
        }
        if (PlayerPrefs.GetFloat("SFX") == 0)
        {
            PlayerPrefs.SetFloat("SFX", 0.5f);
        }
        PlayerPrefs.SetFloat("MUSIC", MusicSlider.value);
        PlayerPrefs.SetFloat("SFX", SFXSlider.value);
        MusicVolume.volume = PlayerPrefs.GetFloat("MUSIC");
        SFXVolume.volume = PlayerPrefs.GetFloat("SFX");
        MusicSlider.value = PlayerPrefs.GetFloat("MUSIC");
        SFXSlider.value = PlayerPrefs.GetFloat("SFX");
    }
    public void Back()
    {
        PauseOBJ.SetActive(false);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
