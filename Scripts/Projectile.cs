using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float duration = 3f;
    public GameObject impactEffect;

    void Awake()
    {
        Destroy(gameObject, duration);
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        EnemyHealth enemyHealth = collision.transform.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }
    }
}
