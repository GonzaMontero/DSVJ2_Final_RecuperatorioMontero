using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] GameObject loadScene;
    [SerializeField] GameObject levelText;
    [SerializeField] GameObject loadCompleteText;
    [SerializeField] float speed;

    GameManager gm;
    Slider sl;
    TextMeshProUGUI text;
    float operation;

    void Start()
    {
        gm = GameManager.Get();
        sl = loadScene.GetComponent<Slider>();
        text = levelText.GetComponent<TextMeshProUGUI>();

        operation = 0;
        text.text = "Level: " + gm.level.ToString();
        switch (gm.level)
        {
            case 1:
                StartCoroutine(LoadAsync());
                break;
            case 2:
                StartCoroutine(LoadAsync());
                break;
            case 3:
                StartCoroutine(LoadAsync());
                break;
            default:
                break;
        }

    }

    void Update()
    {
        if (operation >= 100.0f)
        {
            if (Input.GetMouseButtonDown(0))
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
                    default:
                        break;
                }
            }
        }
    }

    IEnumerator LoadAsync()
    {
        while (operation < 100.0f)
        {
            operation += speed * Time.deltaTime;
            sl.value = operation;
            yield return null;
        }
        if (!loadCompleteText.activeSelf)
        {
            loadCompleteText.SetActive(true);
        }
    }
}
