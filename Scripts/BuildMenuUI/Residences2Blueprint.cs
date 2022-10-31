using UnityEngine;

public class Residences2Blueprint : Blueprints
{
    public override void PlaceBuilding()
    {
        float cost = buildingPrefab.GetComponent<Residences2Needs>().residences2Cost;
        float power = buildingPrefab.GetComponent<Residences2Needs>().residences2Power;
        
        int residents = buildingPrefab.GetComponent<Residences2Population>().residences2Population;

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
