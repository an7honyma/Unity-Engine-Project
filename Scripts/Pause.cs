using UnityEngine;

public class Pause : MonoBehaviour
{
    void Awake()
    {
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
        }
    }
}
