using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonobehaviourSingleton<SceneLoader>
{
    GameManager gm;

    private void Start()
    {
        gm = GameManager.Get();
    }

    public void StartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Loading Bar");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void EndApplication()
    {
        Application.Quit();
    }
}