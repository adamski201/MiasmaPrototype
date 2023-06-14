using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int startHealth = 100;
    private int health;
    public IntEvent onHealthChange;

    void Awake()
    {
        health = startHealth;
    }

    public void ChangeHealth(int amount)
    {
        health += amount;
        onHealthChange?.Invoke(health);

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
