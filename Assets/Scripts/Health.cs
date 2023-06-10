using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int startHealth = 100;
    private int health;
    [SerializeField] private HealthBar healthBar;

    void Awake()
    {
        health = startHealth;
    }

    public void ChangeHealth(int amount)
    {
        health += amount;
        healthBar.SetHealth(health);
    }
}
