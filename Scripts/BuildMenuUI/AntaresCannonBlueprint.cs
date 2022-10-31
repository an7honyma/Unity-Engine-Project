using UnityEngine;

public class AntaresCannonBlueprint : Blueprints
{
    public override void PlaceBuilding()
    {
        float cost = buildingPrefab.GetComponent<AntaresCannonNeeds>().antaresCannonCost;
        float power = buildingPrefab.GetComponent<AntaresCannonNeeds>().antaresCannonPower;
        int workers = buildingPrefab.GetComponent<AntaresCannonNeeds>().antaresCannonWorkers;
        
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
