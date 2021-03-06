using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashFade : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI splashText;
    
    IEnumerator Start()
    {
        splashText.canvasRenderer.SetAlpha(0.0f);

        FadeIn();
        yield return new WaitForSeconds(2.5f);

        FadeOut();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("LoadScene2");
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