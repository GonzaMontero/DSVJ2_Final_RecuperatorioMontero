using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    private Vector2 screenBounds;
    private float objectWidth;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        speedLowered = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector2 currentPos = transform.position;
            currentPos.y += (Input.GetAxisRaw("Vertical") * Time.deltaTime) * movementSpeed;
            transform.position = currentPos;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector2 currentPos = transform.position;
            currentPos.x += (Input.GetAxisRaw("Horizontal") * Time.deltaTime) * movementSpeed;
            transform.position = currentPos;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector2 currentPos = transform.position;
            currentPos.y += (Input.GetAxisRaw("Vertical") * Time.deltaTime) * movementSpeed;
            transform.position = currentPos;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector2 currentPos = transform.position;
            currentPos.x += (Input.GetAxisRaw("Horizontal") * Time.deltaTime) * movementSpeed;
            transform.position = currentPos;
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
