using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerCollisionManager : MonoBehaviour
{
    private Vector3 startPos;
    private GameManager gm;
    private SceneLoader loader;
    private GameObject UIController;

    private void Start()
    {
        gm = GameManager.Get();
        loader = SceneLoader.Get();
        UIController = GameObject.FindGameObjectWithTag("UI");
        startPos = transform.position;    
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
                loader.GoToMenu();
            }
            UIController.GetComponent<UpdateUI>().ReUpdateUI();
        }
        else if(collision.transform.tag=="End Of Level")
        {
            gm.IncreaseScore(100);
            gm.BeatLevel();
        }
    }
}
