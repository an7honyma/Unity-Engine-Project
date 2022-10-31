using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UpgradeHealth : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject avatar;
    private int upgradeHealthKnowledgeCost = 500;
    public TextMeshProUGUI upgradeHealthCost;
    public TextMeshProUGUI upgradeHealthLevel;
    public GameObject descriptionPanel;
    private string[] numerals = new string[] {"I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "MAX"};
    private int level = 0;

    void Start()
    {
        upgradeHealthCost.text = upgradeHealthKnowledgeCost.ToString();
        upgradeHealthLevel.text = numerals[level];
    }

    public void UpgradeAvatarHealth()
    {
        if (ResourceManager.knowledge >= upgradeHealthKnowledgeCost)
        {
            avatar.GetComponent<AvatarHealth>().maxHealth += 500;
            ResourceManager.knowledge -= upgradeHealthKnowledgeCost;
            upgradeHealthKnowledgeCost += 500;
            upgradeHealthCost.text = upgradeHealthKnowledgeCost.ToString();
            level ++;
            upgradeHealthLevel.text = numerals[level];

            if (numerals[level] == "MAX")
            {
                Button button = gameObject.GetComponent<Button>();
                upgradeHealthCost.text = "---";
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
