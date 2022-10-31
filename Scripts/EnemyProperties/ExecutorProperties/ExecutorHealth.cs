using UnityEngine;

public class ExecutorHealth : EnemyHealth
{
    public GameObject artifactPrefab;
    
    public ExecutorHealth()
    {
        enemyHealth = 3500f;
    }

    public override void DropItem()
    {
        Instantiate(artifactPrefab, gameObject.transform.position, Quaternion.identity);
    }
}
