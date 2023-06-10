using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Hittable : MonoBehaviour
{
    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    public void TakeHit(int damage, int knockbackPower, Vector3 knockbackSource)
    {
        TakeDamage(damage);

        if (TryGetComponent(out Knockbackable knockbackableObject))
        {
            knockbackableObject.InflictKnockback(knockbackSource, knockbackPower);
        }
    }

    public void TakeDamage(int amount)
    {
        health.ChangeHealth(-1 * amount);
    }
}
