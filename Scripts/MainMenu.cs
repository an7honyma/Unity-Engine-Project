using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public AudioSource gameMenuButton;
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void NewGame()
    {
        StartCoroutine(LoadNewGame());
    }

    IEnumerator LoadNewGame()
    {
        gameMenuButton.Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void OpenOptionsMenu()
    {
        gameMenuButton.Play();
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void CloseOptionsMenu()
    {
        gameMenuButton.Play();
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        StartCoroutine(ExitApplication());
    }

    IEnumerator ExitApplication()
    {
        gameMenuButton.Play();
        yield return new WaitForSeconds(0.5f);
        gameMenuButton.Play();
        Application.Quit();
    }
}
