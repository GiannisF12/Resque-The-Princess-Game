using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject OptionsMenu, MainMenu;
    public Animator anim;
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Options()
    {
        OptionsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void Back()
    {
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void SatrtGameBut()
    {
        anim.Play("StartGame", 0);
    }

    public void StartGameAnim()
    {
        SceneManager.LoadScene(1);
    }
}
