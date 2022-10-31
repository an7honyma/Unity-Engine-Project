using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EnableShieldDeployment : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject shieldDeploymentButtonContainer;
    private int shieldKnowledgeCost = 100;
    public TextMeshProUGUI enableShieldCost;
    public TextMeshProUGUI enableShieldLevel;
    public GameObject descriptionPanel;
    private string[] numerals = new string[] {"I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "MAX"};
    private int level = 0;

    void Start()
    {
        enableShieldCost.text = shieldKnowledgeCost.ToString();
        enableShieldLevel.text = numerals[level];
    }

    public void EnableShieldDeploymentButton()
    {
        if (ResourceManager.knowledge >= shieldKnowledgeCost)
        {
            shieldDeploymentButtonContainer.SetActive(true);
            ResourceManager.knowledge -= shieldKnowledgeCost;
            AvatarAbilities.ShieldLevelUp();
            shieldKnowledgeCost += 100;
            enableShieldCost.text = shieldKnowledgeCost.ToString();
            level ++;
            enableShieldLevel.text = numerals[level];

            if (numerals[level] == "MAX")
            {
                Button button = gameObject.GetComponent<Button>();
                enableShieldCost.text = "---";
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
