using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class EnergyBar : MonoBehaviour
{
    public Slider energySlider;
    public TextMeshProUGUI energyText;

    void Start()
    {
        InvokeRepeating("UpdateEnergyText", 0f, 0.25f);
    } 

    public void SetTotalEnergy(float energy)
    {
        energySlider.maxValue = energy;
    }

    public void SetEnergyLevel(float energy)
    {
        energySlider.value = energy;
    }

    void UpdateEnergyText()
    {
        energyText.text = Math.Round(AvatarRequirements.energy).ToString();
    }
}
