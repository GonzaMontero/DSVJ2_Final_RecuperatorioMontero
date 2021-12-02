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
        switch (gm.level)
        {
            case 1:
                SceneManager.LoadScene("Level 1");
                break;
            case 2:
                SceneManager.LoadScene("Level 2");
                break;
            case 3:
                SceneManager.LoadScene("Level 3");
                break;
        }
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