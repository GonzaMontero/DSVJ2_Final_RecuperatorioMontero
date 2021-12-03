using UnityEngine;
using TMPro;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerCollisionManager : MonoBehaviour
{
    [SerializeField] GameObject winUI;
    [SerializeField] GameObject loseUI;

    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI scoreText;

    private Vector3 startPos;
    private GameManager gm;
    private GameObject UIController;

    private void Start()
    {
        gm = GameManager.Get();
        UIController = GameObject.FindGameObjectWithTag("UI");
        startPos = transform.position;
        Time.timeScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            transform.position = startPos;
            transform.rotation = Quaternion.identity;
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y + 4, Camera.main.transform.position.z);
            gm.LoseLives();
            if (gm.lives <= 0)
            {
                gm.level = 0;
                gm.ResetLives();
                loseUI.SetActive(true);
                Time.timeScale = 0;
            }            
            UIController.GetComponent<UpdateUI>().ReUpdateUI();
        }
        else if(collision.transform.tag=="End Of Level")
        {            
            gm.BeatLevel();
            winUI.SetActive(true);
            timeText.text = "Time Taken: " + UIController.GetComponent<UpdateUI>().GetTimePassed().ToString("F2");
            scoreText.text = "Score: " + gm.score.ToString();
            Time.timeScale = 0;
            gm.IncreaseScore(100);           
        }
    }
}
