﻿using System.Collections;
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

        operation = 0;
        if (gm.level > 3)
        {
            gm.level = 1;
            secretText.SetActive(true);
        }
        text.text = "Level: " + gm.level.ToString();

        StartCoroutine(LoadAsync());
    }

    void Update()
    {
        if (operation >= 100.0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gm.score = LoadManager<int>.LoadDataFromFile( Application.persistentDataPath + "Saved Data.bat");
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
                        gm.level = 1;
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
