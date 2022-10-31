using UnityEngine;

public class SpaceAuthoritiesBlueprint : Blueprints
{
    public override void PlaceBuilding()
    {
        float cost = buildingPrefab.GetComponent<SpaceAuthoritiesNeeds>().spaceAuthoritiesCost;
        float power = buildingPrefab.GetComponent<SpaceAuthoritiesNeeds>().spaceAuthoritiesPower;
        int workers = buildingPrefab.GetComponent<SpaceAuthoritiesNeeds>().spaceAuthoritiesWorkers;

        bool sufficient_credits = cost <= ResourceManager.credits;
        bool sufficient_power = power <= ResourceManager.excessPower;
        bool sufficient_workers = workers <= ResourceManager.surplusPopulation;

        if (sufficient_credits && sufficient_power && sufficient_workers)
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
        else if (!sufficient_workers)
        {
            NotificationManager.insufficientWorkers = true;
        }
    }
}
