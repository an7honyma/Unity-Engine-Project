using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingStatusPanel : MonoBehaviour
{
    public static string buildingName;
    public static float buildingHealth;
    public static float buildingMaxHealth;
    public static Sprite buildingImage;

    public TextMeshProUGUI buildingNameField;
    public Image buildingImageField;
    public TextMeshProUGUI buildingHealthField;

    public GameObject buildingStatusPanel;

    void Update()
    {
        if (buildingName != null && !BuildToggle.bulldozeMode)
        {
            buildingNameField.text = buildingName;
            buildingImageField.sprite = buildingImage;
            buildingHealthField.text = buildingHealth.ToString();
            if (!buildingStatusPanel.activeSelf)
            {
                buildingStatusPanel.SetActive(true);
            }
        }
        else
        {
            buildingStatusPanel.SetActive(false);
        }
    }
}
