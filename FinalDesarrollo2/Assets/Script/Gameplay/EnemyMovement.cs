using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMovement : MonoBehaviour
{
    [Header("Enemy Properties")]
    [SerializeField] float enemySpeed;

    enum sideOfSpawn {left, right};
    [SerializeField] sideOfSpawn side;


    private Vector2 screenBounds;
    private float objectWidth;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        enemySpeed *= 1.5f;
    }

    void Update()
    {
        Vector2 currentPos;
        switch (side)
        {
            case sideOfSpawn.left:
                currentPos = transform.position;
                currentPos.x += enemySpeed * Time.deltaTime;
                transform.position = currentPos;
                break;
            case sideOfSpawn.right:
                currentPos = transform.position;
                currentPos.x -= enemySpeed * Time.deltaTime;
                transform.position = currentPos;
                break;
            default:
                break;
        }
        CompareSides();
    }

    void CompareSides()
    {
        Vector3 newPos=transform.position;
        switch (side)
        {
            case sideOfSpawn.left:
                if (transform.position.x - objectWidth > (screenBounds.x * -1) )
                {
                    side = sideOfSpawn.right;
                    //newPos.x = screenBounds.x - objectWidth;
                    //transform.position = newPos;
                }
                break;
            case sideOfSpawn.right:
                if (transform.position.x + objectWidth < (screenBounds.x))
                {
                    side = sideOfSpawn.left;
                    //newPos.x = -screenBounds.x + objectWidth;
                    //transform.position = newPos;
                }
                break;
            default:
                break;
        }
    }
}
