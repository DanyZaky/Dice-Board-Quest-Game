using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public AudioSource sfxButton;

    public void SFXButton()
    {
        sfxButton.Play();
    }

    public void ExitButton()
    {
        SFXButton();
        Application.Quit();
    }

    public void StartButton()
    {
        SFXButton();
        SceneManager.LoadScene(1);
    }
}
