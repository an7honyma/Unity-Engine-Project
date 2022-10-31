using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float enemyDamage;
    public float duration = 3f;
    public GameObject enemyImpactEffect;

    void Awake()
    {
        Destroy(gameObject, duration);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        Instantiate(enemyImpactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Health health = collision.transform.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(enemyDamage);
        }
    }
}