using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildToggle : MonoBehaviour
{
    public static bool isBuilding = false;
    public static GameObject currentProductionMenu;
    public static bool onProductionMenu = false;
    public static bool onPlayerInterface = false;
    public static bool bulldozeMode = false;
    public static GameObject buildingToDelete;
    public static string buildingToDeleteName;
    public static Sprite buildingToDeleteImage;
    public GameObject bulldozePanel;
    public TextMeshProUGUI bulldozePanelNameField;
    public Image bulldozePanelImageField;
    public static bool setBulldozeDetails = false;
    public GameObject buildMenu;

    public static int spaceAuthorities;
    public Button[] productionBuildingButtons;
    public Image[] productionBuildingLockIcons;
    public static int defenceBureaus;
    public Button[] turretButtons;
    public Image[] turretLockIcons;

    public AudioSource gameMenuButton;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isBuilding)
        {
            gameMenuButton.Play();
            isBuilding = true;
            buildMenu.SetActive(true);
            SelectedUnits.selectUnits = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && isBuilding)
        {
            gameMenuButton.Play();
            isBuilding = false;
            buildMenu.SetActive(false);
        }
        else if (!isBuilding)
        {
            buildMenu.SetActive(false);
        }

        if (spaceAuthorities > 0)
        {
            EnableProductionBuildingButtons();
        }
        else if (spaceAuthorities == 0)
        {
            DisableProductionBuildingButtons();
        }

        if (defenceBureaus > 0)
        {
            EnableTurretButtons();
        }
        else if (defenceBureaus == 0)
        {
            DisableTurretButtons();
        }

        if (!isBuilding)
        {
            bulldozeMode = false;
            buildingToDelete = null;
        }

        if (buildingToDelete != null)
        {
            bulldozePanel.SetActive(true);
            if (!setBulldozeDetails)
            {
                bulldozePanelNameField.text = buildingToDeleteName;
                bulldozePanelImageField.sprite = buildingToDeleteImage;
                setBulldozeDetails = true;
            }
        }
        else
        {
            bulldozePanel.SetActive(false);
            setBulldozeDetails = false;
        }
    }

    public void ToggleBuildMenu()
    {
        bool isActive = buildMenu.activeSelf;
        gameMenuButton.Play();
        buildMenu.SetActive(!isActive);
        BuildToggle.isBuilding = !BuildToggle.isBuilding;
    }

    void EnableProductionBuildingButtons()
    {
        foreach (Button button in productionBuildingButtons)
        {
            button.interactable = true;
        }
        foreach (Image image in productionBuildingLockIcons)
        {
            image.enabled = false;
        }
    }

    void DisableProductionBuildingButtons()
    {
        foreach (Button button in productionBuildingButtons)
        {
            button.interactable = false;
        }
        foreach (Image image in productionBuildingLockIcons)
        {
            image.enabled = true;
        }
    }

    void EnableTurretButtons()
    {
        foreach (Button button in turretButtons)
        {
            button.interactable = true;
        }
        foreach (Image image in turretLockIcons)
        {
            image.enabled = false;
        }
    }

    void DisableTurretButtons()
    {
        foreach (Button button in turretButtons)
        {
            button.interactable = false;
        }
        foreach (Image image in turretLockIcons)
        {
            image.enabled = true;
        }
    }
}
