using UnityEngine;
using System.Collections;

public class TheTowerHealth : Health
{
    public GameObject canvas;

    public TheTowerHealth()
    {
        maxHealth = 1500f;
        health = 1500f;
    }

    public override void Die()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        if (fracturedPrefab != null)
        {
            Instantiate(fracturedPrefab, transform.position, transform.rotation);
        }
        canvas.GetComponent<GameOutcome>().LoseGame();
        Destroy(gameObject);
        
    }
}