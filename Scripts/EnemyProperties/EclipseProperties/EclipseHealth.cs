using UnityEngine;

public class EclipseHealth : EnemyHealth
{
    public GameObject artifactPrefab;
    
    public EclipseHealth()
    {
        enemyHealth = 3500f;
    }

    public override void DropItem()
    {
        Instantiate(artifactPrefab, gameObject.transform.position, Quaternion.identity);
    }
}
