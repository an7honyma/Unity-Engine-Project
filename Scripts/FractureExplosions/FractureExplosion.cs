using UnityEngine;

public class FractureExplosion : MonoBehaviour
{
    private float minForce = 5f;
    private float maxForce = 100f;
    private float forceRadius = 10f;

    void Start()
    {
        foreach (Transform fracture in gameObject.transform)
        {
            var rb = fracture.GetComponent<Rigidbody>();
            rb.AddExplosionForce(Random.Range(minForce, maxForce), transform.position, forceRadius);
        }
        Destroy(gameObject, 5f);
    }
}
