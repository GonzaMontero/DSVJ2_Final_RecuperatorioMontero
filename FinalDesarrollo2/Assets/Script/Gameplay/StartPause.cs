using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPause : MonoBehaviour
{
    private bool paused;
    [SerializeField] GameObject[] pauseButtons;

    private void Start()
    {
        paused = false;
    }

    public void Pause()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            foreach (GameObject item in pauseButtons)
            {
                item.SetActive(true);
            }
            paused = true;
        }
        else
        {
            foreach (GameObject item in pauseButtons)
            {
                item.SetActive(false);
            }
            Time.timeScale = 1;
            paused = false;
        }
    }

    public void RestartLevel()
    {
        GameManager.Get().ResetLives();
        SceneLoader.StartLevel();
    }

    public void GoToMenu()
    {
        SceneLoader.GoToMenu();
    }
}
