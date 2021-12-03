using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [Range(1, 10)]
    [SerializeField] float smoothFactor;

    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(transform.position.x, player.position.y + 4, transform.position.z);
        Vector3 smoothPos = Vector3.Lerp(transform.position, newPos, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPos;
    }
}
