using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UpgradeMaxEnergy : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject avatar;
    private int upgradeMaxEnergyKnowledgeCost = 500;
    public TextMeshProUGUI upgradeMaxEnergyCost;
    public TextMeshProUGUI upgradeMaxEnergyLevel;
    public GameObject descriptionPanel;
    private string[] numerals = new string[] {"I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "MAX"};
    private int level = 0;

    void Start()
    {
        upgradeMaxEnergyCost.text = upgradeMaxEnergyKnowledgeCost.ToString();
        upgradeMaxEnergyLevel.text = numerals[level];
    }

    public void UpgradeAvatarMaxEnergy()
    {
        if (ResourceManager.knowledge >= upgradeMaxEnergyKnowledgeCost)
        {
            AvatarRequirements.maxEnergy += 500;
            ResourceManager.knowledge -= upgradeMaxEnergyKnowledgeCost;
            upgradeMaxEnergyKnowledgeCost += 500;
            upgradeMaxEnergyCost.text = upgradeMaxEnergyKnowledgeCost.ToString();
            level ++;
            upgradeMaxEnergyLevel.text = numerals[level];

            if (numerals[level] == "MAX")
            {
                Button button = gameObject.GetComponent<Button>();
                upgradeMaxEnergyCost.text = "---";
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
