using UnityEngine;
using System.Collections;

public class FleetGrouping : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine(RemoveGrouping());
    }

    IEnumerator RemoveGrouping()
    {
        foreach (Transform child in transform)
        {
            child.transform.parent = null;
        }
        yield return new WaitForSeconds(3);
        // Destroy(gameObject);
    }
}
