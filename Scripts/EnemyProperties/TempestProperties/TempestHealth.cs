using UnityEngine;
using System.Collections;

public class TempestHealth : EnemyHealth
{
    private float maxHealth;
    public GameObject shieldPrefab;
    private bool shieldActivated = false;
    public GameObject artifactPrefab;

    public TempestHealth()
    {
        enemyHealth = 1500f;
    }

    void Start()
    {
        maxHealth = enemyHealth;
    }
    void Update()
    {
        if (enemyHealth/maxHealth <= 0.5 && !shieldActivated)
        {
            var forceField = Instantiate(shieldPrefab, transform.position, transform.rotation);
            forceField.GetComponent<UnitForceField>().parentUnit = gameObject.transform;
            shieldActivated = true;
        }
    }

    public override void DropItem()
    {
        Instantiate(artifactPrefab, gameObject.transform.position, Quaternion.identity);
    }
}
