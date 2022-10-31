using UnityEngine;

public class PlatformCannonHealth : Health
{
    public PlatformCannonHealth()
    {
        maxHealth = 2000f;
        health = 2000f;
    }

    public override void Die()
    {
        gameObject.GetComponent<PlatformCannonRepair>().DeactivatePlatformCannonMaterials();
        Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
        gameObject.GetComponent<PlatformCannon>().enabled = false;
        ResourceManager.excessPower += gameObject.GetComponent<PlatformCannonNeeds>().platformCannonPower;
        gameObject.tag = "Untagged";
    }
}
