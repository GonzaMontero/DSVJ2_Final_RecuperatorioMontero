using UnityEngine;
using TMPro;

public class UpdateUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    private GameManager gm;
    private float timePassed;

    void Start()
    {
        timePassed = 0;
        gm = GameManager.Get();

        livesText.text = "Lives: " + gm.lives.ToString();
        scoreText.text = "Score: " + gm.score.ToString();
    }

    public float GetTimePassed()
    {
        return timePassed;
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        timeText.text = "Time: " + timePassed.ToString("F2"); 
    }

    public void ReUpdateUI()
    {
        livesText.text = "Lives: " + gm.lives.ToString();
        scoreText.text = "Score: " + gm.score.ToString();
    }
}
