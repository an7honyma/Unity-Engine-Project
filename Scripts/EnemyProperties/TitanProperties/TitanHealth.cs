using UnityEngine;

public class TitanHealth : EnemyHealth
{
    public GameObject artifactPrefab;
    
    public TitanHealth()
    {
        enemyHealth = 3000f;
    }

    public override void DropItem()
    {
        Instantiate(artifactPrefab, gameObject.transform.position, Quaternion.identity);
    }
}