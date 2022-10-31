using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EnableRepairStationDeployment : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject repairStationDeploymentButtonContainer;
    private int repairStationKnowledgeCost = 400;
    public TextMeshProUGUI enableRepairStationCost;
    public TextMeshProUGUI enableRepairStationLevel;
    public GameObject descriptionPanel;
    private string[] numerals = new string[] {"I", "MAX"};
    private int level = 0;

    void Start()
    {
        enableRepairStationCost.text = repairStationKnowledgeCost.ToString();
        enableRepairStationLevel.text = numerals[level];
    }

    public void EnableRepairStationDeploymentButton()
    {
        if (ResourceManager.knowledge >= repairStationKnowledgeCost)
        {
            repairStationDeploymentButtonContainer.SetActive(true);
            ResourceManager.knowledge -= repairStationKnowledgeCost;
            AvatarAbilities.RepairStationLevelUp();
            repairStationKnowledgeCost += 300;
            enableRepairStationCost.text = repairStationKnowledgeCost.ToString();
            level ++;
            enableRepairStationLevel.text = numerals[level];

            if (numerals[level] == "MAX")
            {
                Button button = gameObject.GetComponent<Button>();
                enableRepairStationCost.text = "---";
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
