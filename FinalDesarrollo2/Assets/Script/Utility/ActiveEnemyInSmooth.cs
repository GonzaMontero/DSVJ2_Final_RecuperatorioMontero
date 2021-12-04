using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEnemyInSmooth : MonoBehaviour
{
    void Start()
    {
        if (!GameManager.Get().isSmoothMode)
        {
            transform.gameObject.SetActive(false);
        }
    }
}
