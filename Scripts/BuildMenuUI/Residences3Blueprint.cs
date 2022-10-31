using UnityEngine;

public class Residences3Blueprint : Blueprints
{
    public override void PlaceBuilding()
    {
        float cost = buildingPrefab.GetComponent<Residences3Needs>().residences3Cost;
        float power = buildingPrefab.GetComponent<Residences3Needs>().residences3Power;
        
        int residents = buildingPrefab.GetComponent<Residences3Population>().residences3Population;

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
