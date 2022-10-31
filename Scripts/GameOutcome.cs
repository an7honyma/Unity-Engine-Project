using System.Collections;
using UnityEngine;

public class GameOutcome : MonoBehaviour
{
    public GameObject gameLostScreen;

    public void LoseGame()
    {
        StartCoroutine(DisplayLoseScreen());
    }

    public IEnumerator DisplayLoseScreen()
    {
        yield return new WaitForSeconds(3);
        gameLostScreen.SetActive(true);
        yield return new WaitForSeconds(7);
        Time.timeScale = 0f;
    }
}
