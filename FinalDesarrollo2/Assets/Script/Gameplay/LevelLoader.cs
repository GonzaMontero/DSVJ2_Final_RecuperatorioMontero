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
    [SerializeField] GameObject secretText;
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

        GameManager.GameData temp = new GameManager.GameData();
        string jsonData;
        jsonData = LoadManager<string>.LoadDataFromFile(Application.persistentDataPath + "/Saved Data.bin");
        JsonUtility.FromJsonOverwrite(jsonData, temp);
        if (temp.level > 0)
        {
            gm.data = temp;
        }


        operation = 0;
        if (gm.data.level > 3)
        {
            gm.data.level = 1;
            secretText.SetActive(true);
        }
        text.text = "Level: " + gm.data.level.ToString();

        StartCoroutine(LoadAsync());
    }

    void Update()
    {
        if (operation >= 100.0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                switch (gm.data.level)
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
                        gm.data.level = 1;
                        SceneManager.LoadScene("Level 1");
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
