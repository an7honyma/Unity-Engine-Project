using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    public bool isDead = false;

    public GameObject enemyExplosionPrefab;
    public GameObject fracturedPrefab;

    public void TakeDamage (float damageAmount)
    {
        enemyHealth -= damageAmount;
        if (enemyHealth <= 0f)
        {
            if (isDead == false)
            {
                Die();
                isDead = true;
            }
        }
    }
    
    void Die()
    {
        Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
        Instantiate(fracturedPrefab, transform.position, transform.rotation);
        DropItem();
        ResourceManager.killCount ++;
        Destroy(gameObject);
    }

    public virtual void DropItem()
    {
        // Drop artifacts.
    }
}
