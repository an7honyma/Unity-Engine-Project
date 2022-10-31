using UnityEngine;

public class TogglePlayerInterface : MonoBehaviour
{
    public GameObject playerInterface;
    public AudioSource gameMenuButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !playerInterface.activeSelf)
        {
            gameMenuButton.Play();
            playerInterface.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && playerInterface.activeSelf)
        {
            gameMenuButton.Play();
            playerInterface.SetActive(false);
        }

    }
}
