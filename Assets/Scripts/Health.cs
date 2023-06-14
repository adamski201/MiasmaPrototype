using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int startHealth = 100;
    private int health;
    private HealthBar healthBar;

    void Awake()
    {
        health = startHealth;
        healthBar = GetComponent<HealthBar>();
    }

    public void ChangeHealth(int amount)
    {
        health += amount;

        if (healthBar != null)
        {
            healthBar.SetHealth(health);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
