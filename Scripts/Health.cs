using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public bool isDead = false;
    public GameObject explosionPrefab;
    public GameObject fracturedPrefab;

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0f)
        {
            health = 0f;
            if (isDead == false)
            {
                Die();
                isDead = true;
            }
        }
    }

    public void Heal(float healAmount)
    {
        if (health < maxHealth)
        {
            health += healAmount;
        }
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }
    
    public virtual void Die()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        PlayerMovement player = gameObject.GetComponent<PlayerMovement>();
        if (player == null)
        {
            if (fracturedPrefab != null)
            {
                Instantiate(fracturedPrefab, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
        else
        {
            transform.GetComponent<Rigidbody>().drag = 1f;
            transform.GetComponent<Rigidbody>().angularDrag = 1f;
            transform.GetComponent<Rigidbody>().useGravity = true;
            player.GetComponent<PlayerMovement>().enabled = false;
        }
        if (gameObject.tag == "Droid" || gameObject.tag == "Ship" || gameObject.tag == "Vehicle")
        {
            gameObject.tag = "Untagged";
        }
    }
}