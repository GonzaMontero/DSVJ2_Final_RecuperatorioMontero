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

        livesText.text = "Lives: ";
        //scoreText.text = "Score: " + gm.score;
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        timeText.text = "Time: " + timePassed.ToString("F2"); 
    }
}
