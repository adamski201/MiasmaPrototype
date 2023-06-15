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

    public void TakeHit(Hit hit)
    {
        if (hit.damageType == damageType)
        {
            TakeDamage(hit.damage);

            if (knockback != null)
            {
                knockback.InflictKnockback(hit.knockbackSource, hit.knockbackForce);
            }
        }
    }

    public void TakeDamage(int amount)
    {
        health.ChangeHealth(-1 * amount);
    }
}
