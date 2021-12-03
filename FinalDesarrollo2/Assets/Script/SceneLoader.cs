using UnityEngine;
using UnityEngine.SceneManagement;

static public class SceneLoader
{
    static public void StartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Loading Bar");
    }

    static public void GoToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    static public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    static public void EndApplication()
    {
        Application.Quit();
    }
}