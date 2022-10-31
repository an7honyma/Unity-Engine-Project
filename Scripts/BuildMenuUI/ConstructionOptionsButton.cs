using UnityEngine;

public class ConstructionOptionsButton : MonoBehaviour
{
    public GameObject panel;
    public GameObject[] otherPanels;
    public AudioSource interfaceMenuButton;

    public void OpenPanel()
    {
        interfaceMenuButton.Play();
        // Activate panel:
        panel.SetActive(true);
        // Disable other panels:
        for (int i = 0; i < otherPanels.Length; i++)
        {
            otherPanels[i].SetActive(false);
        }
    }
}
