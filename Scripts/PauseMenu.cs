using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject loseGameScreen;
    public Slider musicSlider;
    public Slider SFXSlider;
    public AudioSource gameMenuButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !loseGameScreen.activeSelf)
        {
            if (pauseMenuUI.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }       
    }

    public void ResumeGame()
    {
        gameMenuButton.Play();
        pauseMenuUI.SetActive(false);
        TimeManager.isPaused = false;
    }

    void PauseGame()
    {
        gameMenuButton.Play();
        pauseMenuUI.SetActive(true);
        TimeManager.isPaused = true;
    }

    public void OpenPauseMenu()
    {
        gameMenuButton.Play();
        pauseMenuUI.SetActive(true);
        TimeManager.isPaused = true;
    }

    public void LoadMainMenu()
    {
        StartCoroutine(EnterMainMenu());
    }

    IEnumerator EnterMainMenu()
    {
        gameMenuButton.Play();
        yield return new WaitForSecondsRealtime(0.5f);
        TimeManager.isPaused = false;
        SceneManager.LoadScene("MainMenuScene");
        BuildToggle.isBuilding = false;
        SelectedUnits.selectUnits = false;
    }
}
