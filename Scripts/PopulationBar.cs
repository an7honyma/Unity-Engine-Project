using UnityEngine;
using UnityEngine.UI;

public class PopulationBar : MonoBehaviour
{
    public Slider populationSlider;

    public void SetTotalPopulation(int population)
    {
        populationSlider.maxValue = population;
    }

    public void SetExcessPopulation(int population)
    {
        populationSlider.value = population;
    }
}
