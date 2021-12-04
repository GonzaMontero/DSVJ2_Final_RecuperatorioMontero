using UnityEngine;
using UnityEngine.UI;

public class AddFunctionToButtons : MonoBehaviour
{
    [Header("Button types")]
    [SerializeField] Button playButton;
    [SerializeField] Button creditsButton;
    [SerializeField] Button goToMenuButton;
    [SerializeField] Button exitGameButton;
    [SerializeField] Button restartButton;
    [SerializeField] Button switchDifficultyButton;

    void OnEnable()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(delegate { SceneLoader.StartLevel(); });
        }
        if (creditsButton != null)
        {
            creditsButton.onClick.AddListener(delegate { SceneLoader.GoToCredits(); });
        }
        if (goToMenuButton != null)
        {
            goToMenuButton.onClick.AddListener(delegate { SceneLoader.GoToMenu(); });
        }
        if (exitGameButton != null)
        {
            exitGameButton.onClick.AddListener(delegate { SceneLoader.EndApplication(); });
        }
        if (restartButton != null)
        {
            GameManager gm = GameManager.Get();
            gm.ResetLives();
            gm.data.level = 1;
            restartButton.onClick.AddListener(delegate { SceneLoader.StartLevel(); });
        }
        if (switchDifficultyButton != null)
        {          
            switchDifficultyButton.onClick.AddListener(delegate { GameManager.Get().StartSmoothMode(); ; });
        }
    }
}
