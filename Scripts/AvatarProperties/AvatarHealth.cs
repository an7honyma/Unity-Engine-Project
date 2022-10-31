using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class AvatarHealth : Health
{
    public HealthBar healthBar;
    public float regenRate = 0f;
    public TextMeshProUGUI healthText;
    public GameObject canvas;

    public AvatarHealth()
    {
        maxHealth = 1000f;
        health = 1000f;
    }

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(health);
        InvokeRepeating("UpdateHealthText", 0f, 0.5f);
    }

    void Update()
    {
        if (Time.timeScale == 1f)
        {
            if (health < maxHealth && health > 0)
            {
                health += regenRate;
            }
            else if (health >= maxHealth)
            {
                health = maxHealth;
            }
        }
        if (health <= 0)
        {
            canvas.GetComponent<GameOutcome>().LoseGame();
        }
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(health);
    }

    void UpdateHealthText()
    {
        healthText.text = Math.Round(health).ToString() + "/" + maxHealth.ToString();
    }
}