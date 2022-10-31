using UnityEngine;

public class DarkNebulaHealth : Health
{
    public GameObject forceFieldPrefab;
    private bool forceFieldDeployed = false;
    
    public DarkNebulaHealth()
    {
        maxHealth = 1500f;
        health = 1500f;
    }

    void Update()
    {
        if (health/maxHealth <= 0.5 && !forceFieldDeployed)
        {
            forceFieldDeployed = true;
            var forceField = Instantiate(forceFieldPrefab, transform.position, transform.rotation);
            forceField.GetComponent<UnitForceField>().parentUnit = gameObject.transform;
        }
        else if (health/maxHealth >= 0.75 && forceFieldDeployed)
        {
            forceFieldDeployed = false;
        }
    }
}