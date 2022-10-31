using UnityEngine;

public class TrailEffect : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2f);
    }
}
