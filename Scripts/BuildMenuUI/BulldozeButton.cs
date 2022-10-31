using UnityEngine;
using UnityEngine.UI;

public class BulldozeButton : MonoBehaviour
{
    public AudioSource gameMenuButton;

    public void ToggleBulldozeMode()
    {
        gameMenuButton.Play();
        if (BuildToggle.bulldozeMode)
        {
            BuildToggle.bulldozeMode = false;
            BuildToggle.buildingToDelete = null;
            BuildToggle.buildingToDeleteName = null;
            BuildToggle.buildingToDeleteImage = null;
        }
        else
        {
            BuildToggle.bulldozeMode = true;
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            gameMenuButton.Play();
            if (BuildToggle.bulldozeMode)
            {
                BuildToggle.bulldozeMode = false;
                BuildToggle.buildingToDelete = null;
                BuildToggle.buildingToDeleteName = null;
                BuildToggle.buildingToDeleteImage = null;
            }
            else
            {
                BuildToggle.bulldozeMode = true;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (BuildToggle.bulldozeMode)
            {
                BuildToggle.bulldozeMode = false;
                BuildToggle.buildingToDelete = null;
                BuildToggle.buildingToDeleteName = null;
                BuildToggle.buildingToDeleteImage = null;
            }
        }
    }
}
