using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Hittable : MonoBehaviour
{
    private Health health;
    private Knockbackable knockback;

    private void Awake()
    {
        health = GetComponent<Health>();
        knockback = GetComponent<Knockbackable>();
    }

    public void TakeHit(int damage, int knockbackPower, Vector3 knockbackSource)
    {
        TakeDamage(damage);

        if (knockback != null)
        {
            knockback.InflictKnockback(knockbackSource, knockbackPower);
        }
    }

    public void TakeDamage(int amount)
    {
        health.ChangeHealth(-1 * amount);
    }
}
