using UnityEngine;

public class GameManager : MonobehaviourSingleton<GameManager>
{
    public int level = 1; 
    public void BeatLevel()
    {
        level++;
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
}
