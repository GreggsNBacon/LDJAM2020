using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    private  bool isPaused = false;
    [SerializeField]
    private GameObject pauseUI;

    private MainInput input;

    private void Start()
    {
        input = new MainInput();
        input.Car.Pause.performed += x => HandlePause();
        input.Car.Pause.Enable();
        pauseUI.SetActive(false);
    }

    private void HandlePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}


