using UnityEngine;

public class HealProjectile : MonoBehaviour
{
    public float duration = 3f;
    public GameObject healImpactEffect;

    void Awake()
    {
        Destroy(gameObject, duration);
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(healImpactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
