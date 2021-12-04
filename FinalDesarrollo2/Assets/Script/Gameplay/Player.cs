using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float casualMovementSpeed;
    [SerializeField] float smoothMovementSpeed;
    private Vector2 screenBounds;
    private float objectWidth;
    private Vector3 target;
    bool isMoving;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        speedLowered = false;
        isMoving = false;
        if (GameManager.Get().isSmoothMode)
        {
            transform.localScale = new Vector3(0.75f, 0.75f, 1);
        }
    }

    void Update()
    {
        if (GameManager.Get().isSmoothMode)
        {
            if (Input.GetKey(KeyCode.W)){
                Vector2 currentPos = transform.position;
                currentPos.y += (Input.GetAxisRaw("Vertical") * Time.deltaTime) * smoothMovementSpeed;
                transform.position = currentPos;
            }
            if (Input.GetKey(KeyCode.A)){
                Vector2 currentPos = transform.position;
                currentPos.x += (Input.GetAxisRaw("Horizontal") * Time.deltaTime) * smoothMovementSpeed;
                transform.position = currentPos;
            }
            if (Input.GetKey(KeyCode.S)){
                Vector2 currentPos = transform.position;
                currentPos.y += (Input.GetAxisRaw("Vertical") * Time.deltaTime) * smoothMovementSpeed;
                transform.position = currentPos;
            }
            if (Input.GetKey(KeyCode.D)){
                Vector2 currentPos = transform.position;
                currentPos.x += (Input.GetAxisRaw("Horizontal") * Time.deltaTime) * smoothMovementSpeed;
                transform.position = currentPos;
            }
        }
        else
        {
            if (!isMoving)
            {
                if (Input.GetKeyUp(KeyCode.W))
                {
                    target = transform.position;
                    target.y += 1f;
                    isMoving = true;
                }
                if (Input.GetKeyUp(KeyCode.A))
                {
                    target = transform.position;
                    target.x -= 1f;
                    isMoving = true;
                }
                if (Input.GetKeyUp(KeyCode.S))
                {
                    target = transform.position;
                    target.y -= 1f;
                    isMoving = true;
                }
                if (Input.GetKeyUp(KeyCode.D))
                {
                    target = transform.position;
                    target.x += 1f;
                    isMoving = true;
                }
            }
            if (isMoving)
            {
                transform.position = Vector3.Lerp(transform.position, target, casualMovementSpeed * Time.deltaTime);
                if (transform.position == target)
                {
                    isMoving = false;
                }
            }
        }      
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objectWidth, screenBounds.x * -1 - objectWidth);
        transform.position = viewPos;
    }

    private bool speedLowered;

    public void ResetTarget()
    {
        target = transform.position;
        isMoving = false;
    }

    public void LowerSpeed()
    {
        casualMovementSpeed /= 2;
        speedLowered = true;
    }

    public void ReturnSpeed()
    {
        casualMovementSpeed *= 2;
        speedLowered = false;
    }

    public bool GetSpeedLowered()
    {
        return speedLowered;
    }
}
