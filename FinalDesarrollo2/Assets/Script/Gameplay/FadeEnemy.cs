using System.Collections;
using UnityEngine;

public class FadeEnemy : MonoBehaviour
{
    [SerializeField] GameObject[] go;
    private void Start()
    {
        StartCoroutine(PhaseEnemy());
    }


    IEnumerator PhaseEnemy()
    {
        while (true)
        {
            foreach (GameObject item in go)
            {
                if (!item.activeSelf)
                    item.SetActive(true);
            }
            yield return new WaitForSeconds(3);
            foreach (GameObject item in go)
            {
                if (item.activeSelf)
                    item.SetActive(false);
            }
            yield return new WaitForSeconds(3);
        }
    }
}
