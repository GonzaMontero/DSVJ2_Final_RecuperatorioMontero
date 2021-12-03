using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SplashFadeImage : MonoBehaviour
{
    [SerializeField] Image splashText;

    IEnumerator Start()
    {
        splashText.canvasRenderer.SetAlpha(0.0f);

        FadeIn();
        yield return new WaitForSeconds(2.5f);

        FadeOut();
        yield return new WaitForSeconds(2.5f);
        SceneLoader.GoToMenu();
    }

    void FadeIn()
    {
        splashText.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void FadeOut()
    {
        splashText.CrossFadeAlpha(0.0f, 1.5f, false);
    }
}
