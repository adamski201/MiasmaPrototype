using UnityEngine;

[RequireComponent(typeof(Health))]
public class Hittable : MonoBehaviour
{
    [SerializeField] private DamageTypes damageType;
    private Health health;
    private Knockbackable knockback;
    private Stunnable stun;

    private void Awake()
    {
        health = GetComponent<Health>();
        knockback = GetComponent<Knockbackable>();
        stun = GetComponent<Stunnable>();
    }

    public void TakeHit(Hit hit)
    {
        if (hit.damageType == damageType)
        {
            TakeDamage(hit.damage);

            if (knockback != null)
            {
                knockback.InflictKnockback(hit.knockbackSource, hit.knockbackForce);
            }

            if (stun != null)
            {
                stun.InflictStun(hit.stunTimer);
            }
        }
    }

    public void TakeDamage(int amount)
    {
        health.ChangeHealth(-1 * amount);
    }
}
