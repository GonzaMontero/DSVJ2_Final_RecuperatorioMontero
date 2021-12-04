﻿using UnityEngine;

public class GameManager : MonobehaviourSingleton<GameManager>
{
    public int level = 1;

    private void Start()
    {
        LoadManager<int>.SaveDataToFile(score, Application.persistentDataPath + "Saved Data.bat");
    }

    public void BeatLevel()
    {
        level++;
        score += (100 * lives);
    }
    public int GetLevel()
    {
        return level;
    }

    public int score = 0;
    public void IncreaseScore(int increase)
    {
        score += increase;
    }
    public int GetScore()
    {
        return score;
    }

    public int lives = 5;
    public void ResetLives()
    {
        lives = 5;
    }
    public void LoseLives()
    {
        lives--;
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
