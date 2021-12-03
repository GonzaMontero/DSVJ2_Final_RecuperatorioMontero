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

    SceneLoader sm;

    void Start()
    {
        sm = SceneLoader.Get();
        if (playButton != null)
        {
            playButton.onClick.AddListener(delegate { sm.StartLevel(); });
        }
        if (creditsButton != null)
        {
            creditsButton.onClick.AddListener(delegate { sm.GoToCredits(); });
        }
        if (goToMenuButton != null)
        {
            goToMenuButton.onClick.AddListener(delegate { sm.GoToMenu(); });
        }
        if (exitGameButton != null)
        {
            exitGameButton.onClick.AddListener(delegate { sm.EndApplication(); });
        }
        if (restartButton != null)
        {
            GameManager gm = GameManager.Get();
            gm.ResetLives();
            gm.level = 1;
            restartButton.onClick.AddListener(delegate { sm.StartLevel(); });
        }
        this.GetComponent<AddFunctionToButtons>().enabled = false;
    }
}
