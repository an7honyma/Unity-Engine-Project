using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject researchMenu;
    public GameObject gameLostMenu;
    public static bool isPaused;

    void Update()
    {
        if (pauseMenu.activeSelf || researchMenu.activeSelf || gameLostMenu.activeSelf)
        {
            Time.timeScale = 0f;
            isPaused = true;

        }
        else
        {
            Time.timeScale = 1f;
            isPaused = false;
        }
    }
}
