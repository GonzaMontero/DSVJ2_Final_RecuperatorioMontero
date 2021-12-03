using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SlimeScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Player p;
            p = collision.transform.GetComponent<Player>();
            if (!p.GetSpeedLowered())
            {
                p.LowerSpeed();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Player p;
            p = collision.transform.GetComponent<Player>();
            if (p.GetSpeedLowered())
            {
                p.ReturnSpeed();
            }
        }
    }
}
