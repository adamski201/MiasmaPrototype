using UnityEngine;

[RequireComponent(typeof(Health))]
public class Hittable : MonoBehaviour
{
    [SerializeField] private DamageTypes damageType;
    private Health health;
    private Knockbackable knockback;

    private void Awake()
    {
        health = GetComponent<Health>();
        knockback = GetComponent<Knockbackable>();
    }

    public void TakeHit(int damage, DamageTypes incomingDamageType, int knockbackPower, Vector3 knockbackSource)
    {
        if (incomingDamageType == damageType)
        {
            TakeDamage(damage);

            if (knockback != null)
            {
                knockback.InflictKnockback(knockbackSource, knockbackPower);
            }
        }
    }

    public void TakeDamage(int amount)
    {
        health.ChangeHealth(-1 * amount);
    }
}
