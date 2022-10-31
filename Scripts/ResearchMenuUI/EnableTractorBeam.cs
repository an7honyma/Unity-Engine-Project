using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EnableTractorBeam : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tractorBeamButtonContainer;
    private int tractorBeamKnowledgeCost = 200;
    public TextMeshProUGUI tractorBeamCost;
    public TextMeshProUGUI tractorBeamLevel;
    public GameObject descriptionPanel;
    private string[] numerals = new string[] {"I", "II", "III", "IV", "V", "MAX"};
    private int level = 0;

    void Start()
    {
        tractorBeamCost.text = tractorBeamKnowledgeCost.ToString();
        tractorBeamLevel.text = numerals[level];
    }

    public void EnableTractorBeamButton()
    {
        if (ResourceManager.knowledge >= tractorBeamKnowledgeCost)
        {
            tractorBeamButtonContainer.SetActive(true);
            ResourceManager.knowledge -= tractorBeamKnowledgeCost;
            AvatarAbilities.TractorBeamLevelUp();
            tractorBeamKnowledgeCost += 100;
            tractorBeamCost.text = tractorBeamKnowledgeCost.ToString();
            level ++;
            tractorBeamLevel.text = numerals[level];

            if (numerals[level] == "MAX")
            {
                Button button = gameObject.GetComponent<Button>();
                tractorBeamCost.text = "---";
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
