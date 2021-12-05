using System;
using UnityEngine;


public class GameManager : MonobehaviourSingleton<GameManager>
{
    [Serializable]
    public class GameData
    {
        public int level;
        public int score = 0;
        public int lives = 5;
    }

    public GameData data;

    private void Start()
    {
        GameData temp = new GameData();
        string jsonData;
        jsonData = LoadManager<string>.LoadDataFromFile(Application.persistentDataPath + "/Saved Data.bin");
        JsonUtility.FromJsonOverwrite(jsonData, temp);
        if (temp.level < 1)
        {
            return;
        }
        data = temp;
    }

    private void OnDestroy()
    {
        if (this == GameManager.Get())
        {
            string jsonData;
            jsonData = JsonUtility.ToJson(data);
            LoadManager<string>.SaveDataToFile(jsonData, Application.persistentDataPath + "/Saved Data.bin");
        }        
    }

    public void BeatLevel()
    {
        data.level++;
        data.score += (50 * data.level);
    }
    public int GetLevel()
    {
        return data.level;
    }
    
    public void IncreaseScore(int increase)
    {
        data.score += increase;
    }
    public int GetScore()
    {
        return data.score;
    }
    
    public void ResetLives()
    {
        data.lives = 5;
    }
    public void LoseLives()
    {
        data.lives--;
    }

    public bool isSmoothMode = false;
    public void StartSmoothMode()
    {
        if (isSmoothMode)
        {
            isSmoothMode = false;
        }
        else
        {
            isSmoothMode = true;
        }
    }
}
