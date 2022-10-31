using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UpgradeRechargeRate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject avatar;
    private int upgradeRechargeRateKnowledgeCost = 500;
    public TextMeshProUGUI upgradeRechargeRateCost;
    public TextMeshProUGUI upgradeRechargeRateLevel;
    public GameObject descriptionPanel;
    private string[] numerals = new string[] {"I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "MAX"};
    private int level = 0;

    void Start()
    {
        upgradeRechargeRateCost.text = upgradeRechargeRateKnowledgeCost.ToString();
        upgradeRechargeRateLevel.text = numerals[level];
    }

    public void UpgradeAvatarRechargeRate()
    {
        if (ResourceManager.knowledge >= upgradeRechargeRateKnowledgeCost)
        {
            AvatarRequirements.rechargeRate += 0.25f;
            ResourceManager.knowledge -= upgradeRechargeRateKnowledgeCost;
            upgradeRechargeRateKnowledgeCost += 500;
            upgradeRechargeRateCost.text = upgradeRechargeRateKnowledgeCost.ToString();
            level ++;
            upgradeRechargeRateLevel.text = numerals[level];

            if (numerals[level] == "MAX")
            {
                Button button = gameObject.GetComponent<Button>();
                upgradeRechargeRateCost.text = "---";
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
