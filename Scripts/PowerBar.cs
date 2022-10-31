using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    public Slider powerSlider;

    public void SetTotalPower(float power)
    {
        powerSlider.maxValue = power;
    }

    public void SetExcessPower(float power)
    {
        powerSlider.value = power;
    }
}
