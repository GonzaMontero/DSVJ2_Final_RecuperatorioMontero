using UnityEngine;
using TMPro;

public class UpdateModeText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        if (GameManager.Get().isSmoothMode)
        {
            text.text = "Smooth Mode";
        }
        else
        {
            text.text = "Casual Mode";
        }
    }

    private void Update()
    {
        if (GameManager.Get().isSmoothMode)
        {
            text.text = "Smooth Mode";
        }
        else
        {
            text.text = "Casual Mode";
        }
    }
}
