using UnityEngine;

public class AvatarRequirements : MonoBehaviour
{
    public static float maxEnergy = 1000f;
    public static float energy = 1000f;
    public static float rechargeRate = 0.1f;
    public EnergyBar energyBar;

    void Start()
    {
        energyBar.SetTotalEnergy(maxEnergy);
        energyBar.SetEnergyLevel(energy);
    }

    void Update()
    {
        if (Time.timeScale == 1f)
        {
            if (energy < maxEnergy)
            {
                energy += rechargeRate;
            }
            else
            {
                energy = maxEnergy;
            }
        }
        energyBar.SetTotalEnergy(maxEnergy);
        energyBar.SetEnergyLevel(energy);
    }
}
