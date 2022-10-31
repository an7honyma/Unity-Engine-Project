using UnityEngine;

public class PhotonTankHealth : Health
{
    public PhotonTankHealth()
    {
        maxHealth = 100f;
        health = 1000f;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Background Landscape"))
        {
            Die();
        }
    }
}