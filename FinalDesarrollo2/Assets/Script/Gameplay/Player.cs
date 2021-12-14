using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float casualMovementSpeed;
    [SerializeField] float smoothMovementSpeed;
    private GameObject endBlocker;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private Vector3 target;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight= transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        speedLowered = false;
        endBlocker = GameObject.FindGameObjectWithTag("End Blocker");
        transform.localScale = new Vector3(0.5f, 0.5f, 1);
    }

    void Update()
    {
        Vector3 newPos = transform.position + new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * smoothMovementSpeed, Input.GetAxisRaw("Vertical") * Time.deltaTime * smoothMovementSpeed, 0);
        transform.position = newPos;  
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
