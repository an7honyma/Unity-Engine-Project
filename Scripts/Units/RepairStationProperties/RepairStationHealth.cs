using UnityEngine;

public class RepairStationHealth : Health
{
    private bool shieldDeployed = false;
    public GameObject repairStationShieldPrefab;

    public RepairStationHealth()
    {
        maxHealth = 200f;
        health = 200f;
    }

    void Update()
    {
        if (health/maxHealth <= 0.5 && !shieldDeployed)
        {
            shieldDeployed = true;
            var shield = Instantiate(repairStationShieldPrefab, transform.position, transform.rotation);
            shield.transform.parent = gameObject.transform;
        }
    }
}