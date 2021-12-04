using UnityEngine;

public class GameManager : MonobehaviourSingleton<GameManager>
{
    public class GameData
    {
        public int level = 1;
        public int score = 0;
        public int lives = 5;
    }

    public GameData data;

    private void Start()
    {
        data = LoadManager<GameData>.LoadDataFromFile(Application.persistentDataPath + "Saved Data.bat");
    }

    private void OnDestroy()
    {
        if (this == GameManager.Get())
        {
            LoadManager<GameManager.GameData>.SaveDataToFile(data, Application.persistentDataPath + "Saved Data.bat");
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
