using UnityEngine;

public class PowerPlantBlueprint : Blueprints
{
    public override void PlaceBuilding()
    {
        float cost = buildingPrefab.GetComponent<PowerPlantNeeds>().powerPlantCost;
        int workers = buildingPrefab.GetComponent<PowerPlantNeeds>().powerPlantWorkers;

        bool sufficient_credits = cost <= ResourceManager.credits;
        bool sufficient_workers = workers <= ResourceManager.surplusPopulation;

        if (sufficient_credits && sufficient_workers)
        {
            Instantiate(buildingPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (!sufficient_credits)
        {
            NotificationManager.insufficientCredits = true;
        }
        else if (!sufficient_workers)
        {
            NotificationManager.insufficientWorkers = true;
        }
    }
}
