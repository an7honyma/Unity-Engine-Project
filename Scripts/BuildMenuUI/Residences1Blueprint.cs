using UnityEngine;

public class Residences1Blueprint : Blueprints
{
    public override void PlaceBuilding()
    {
        float cost = buildingPrefab.GetComponent<Residences1Needs>().residences1Cost;
        float power = buildingPrefab.GetComponent<Residences1Needs>().residences1Power;
        
        int residents = buildingPrefab.GetComponent<Residences1Population>().residences1Population;

        bool sufficient_credits = cost <= ResourceManager.credits;
        bool sufficient_power = power <= ResourceManager.excessPower;

        if (sufficient_credits && sufficient_power)
        {
            Instantiate(buildingPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (!sufficient_credits)
        {
            NotificationManager.insufficientCredits = true;
        }
        else if (!sufficient_power)
        {
            NotificationManager.insufficientPower = true;
        }
    }
}
