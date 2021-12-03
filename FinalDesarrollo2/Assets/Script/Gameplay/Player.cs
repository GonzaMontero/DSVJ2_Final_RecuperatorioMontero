using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed;
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
    }

    void Update()
    {
        if (!isMoving)
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                target = transform.position;
                target.y += 1f;
                isMoving = true;
                //Vector2 currentPos = transform.position;
                //currentPos.y += (Input.GetAxisRaw("Vertical") * Time.deltaTime) * movementSpeed;
                //transform.position = currentPos;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                target = transform.position;
                target.x -= 1f;
                isMoving = true;
                //Vector2 currentPos = transform.position;
                //currentPos.x += (Input.GetAxisRaw("Horizontal") * Time.deltaTime) * movementSpeed;
                //transform.position = currentPos;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                target = transform.position;
                target.y -= 1f;
                isMoving = true;
                //Vector2 currentPos = transform.position;
                //currentPos.y += (Input.GetAxisRaw("Vertical") * Time.deltaTime) * movementSpeed;
                //transform.position = currentPos;
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                target = transform.position;
                target.x += 1f;
                isMoving = true;
                //Vector2 currentPos = transform.position;
                //currentPos.x += (Input.GetAxisRaw("Horizontal") * Time.deltaTime) * movementSpeed;
                //transform.position = currentPos;
            }
        }
        if (isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, target, movementSpeed * Time.deltaTime);
            if (transform.position == target)
            {
                isMoving = false;
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

    public void LowerSpeed()
    {
        movementSpeed /= 2;
        speedLowered = true;
    }

    public void ReturnSpeed()
    {
        movementSpeed *= 2;
        speedLowered = false;
    }

    public bool GetSpeedLowered()
    {
        return speedLowered;
    }
}
