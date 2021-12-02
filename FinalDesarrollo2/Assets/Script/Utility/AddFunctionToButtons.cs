using UnityEngine;
using UnityEngine.UI;

public class AddFunctionToButtons : MonoBehaviour
{
    [Header("Button types")]
    [SerializeField] Button playButton;
    [SerializeField] Button creditsButton;
    [SerializeField] Button goToMenuButton;
    [SerializeField] Button exitGameButton;

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
        this.GetComponent<AddFunctionToButtons>().enabled = false;
    }
}
