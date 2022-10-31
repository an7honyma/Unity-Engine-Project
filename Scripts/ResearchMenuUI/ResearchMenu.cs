using UnityEngine;

public class ResearchMenu : MonoBehaviour
{
    public GameObject researchMenu;
    public AudioSource gameMenuButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !researchMenu.activeSelf)
        {
            OpenResearchMenu();
        }
        else if (Input.GetKeyDown(KeyCode.R) && researchMenu.activeSelf)
        {
            CloseResearchMenu();
        }
    }

    public void OpenResearchMenu()
    {
        gameMenuButton.Play();
        researchMenu.SetActive(true);
    }

    public void CloseResearchMenu()
    {
        gameMenuButton.Play();
        researchMenu.SetActive(false);
    }
}
