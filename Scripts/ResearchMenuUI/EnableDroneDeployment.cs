using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EnableDroneDeployment : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject droneDeploymentButtonContainer;
    private int droneKnowledgeCost = 200;
    public TextMeshProUGUI enableDroneCost;
    public TextMeshProUGUI enableDroneLevel;
    public GameObject descriptionPanel;
    private string[] numerals = new string[] {"I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "MAX"};
    private int level = 0;

    void Start()
    {
        enableDroneCost.text = droneKnowledgeCost.ToString();
        enableDroneLevel.text = numerals[level];
    }

    public void EnableDroneDeploymentButton()
    {
        if (ResourceManager.knowledge >= droneKnowledgeCost)
        {
            droneDeploymentButtonContainer.SetActive(true);
            ResourceManager.knowledge -= droneKnowledgeCost;
            AvatarAbilities.DroneLevelUp();
            droneKnowledgeCost += 200;
            enableDroneCost.text = droneKnowledgeCost.ToString();
            level ++;
            enableDroneLevel.text = numerals[level];

            if (numerals[level] == "MAX")
            {
                Button button = gameObject.GetComponent<Button>();
                enableDroneCost.text = "---";
                button.interactable = false;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionPanel.SetActive(false);
    }
}
