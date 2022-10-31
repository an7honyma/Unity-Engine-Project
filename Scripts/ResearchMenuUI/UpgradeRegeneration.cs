using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UpgradeRegeneration : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject avatar;
    private int upgradeRegenerationKnowledgeCost = 500;
    public TextMeshProUGUI upgradeRegenerationCost;
    public TextMeshProUGUI upgradeRegenerationLevel;
    public GameObject descriptionPanel;
    private string[] numerals = new string[] {"I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "MAX"};
    private int level = 0;

    void Start()
    {
        upgradeRegenerationCost.text = upgradeRegenerationKnowledgeCost.ToString();
        upgradeRegenerationLevel.text = numerals[level];
    }

    public void UpgradeAvatarRegeneration()
    {
        if (ResourceManager.knowledge >= upgradeRegenerationKnowledgeCost)
        {
            avatar.GetComponent<AvatarHealth>().regenRate += 0.5f;
            ResourceManager.knowledge -= upgradeRegenerationKnowledgeCost;
            upgradeRegenerationKnowledgeCost += 500;
            upgradeRegenerationCost.text = upgradeRegenerationKnowledgeCost.ToString();
            level ++;
            upgradeRegenerationLevel.text = numerals[level];

            if (numerals[level] == "MAX")
            {
                Button button = gameObject.GetComponent<Button>();
                upgradeRegenerationCost.text = "---";
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
