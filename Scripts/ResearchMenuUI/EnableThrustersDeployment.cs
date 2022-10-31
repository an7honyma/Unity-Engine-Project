using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EnableThrustersDeployment : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject thrustersDeploymentButtonContainer;
    private int thrustersKnowledgeCost = 300;
    public TextMeshProUGUI enableThrustersCost;
    public TextMeshProUGUI enableThrustersLevel;
    public GameObject descriptionPanel;
    private string[] numerals = new string[] {"I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "MAX"};
    private int level = 0;

    void Start()
    {
        enableThrustersCost.text = thrustersKnowledgeCost.ToString();
        enableThrustersLevel.text = numerals[level];
    }

    public void EnableThrustersDeploymentButton()
    {
        if (ResourceManager.knowledge >= thrustersKnowledgeCost)
        {
            thrustersDeploymentButtonContainer.SetActive(true);
            ResourceManager.knowledge -= thrustersKnowledgeCost;
            AvatarAbilities.ThrustersLevelUp();
            thrustersKnowledgeCost += 300;
            enableThrustersCost.text = thrustersKnowledgeCost.ToString();
            level ++;
            enableThrustersLevel.text = numerals[level];

            if (numerals[level] == "MAX")
            {
                Button button = gameObject.GetComponent<Button>();
                enableThrustersCost.text = "---";
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
