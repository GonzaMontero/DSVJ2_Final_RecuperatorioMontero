using UnityEngine;

public class UILoader : MonoBehaviour
{
    public void ToGame()
    {
        SceneLoader.StartLevel();
    }
    public void ToMenu()
    {
        SceneLoader.GoToMenu();
    }
    public void ToCredits()
    {
        SceneLoader.GoToCredits();
    }
    public void EndGame()
    {
        SceneLoader.EndApplication();
    }
}
