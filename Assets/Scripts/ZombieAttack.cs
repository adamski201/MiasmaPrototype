using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private int knockbackPower = 30;
    [SerializeField] private DamageTypes damageType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidedObject = collision.gameObject;
        TryHitObject(collidedObject);
    }

    void TryHitObject(GameObject objectToHit)
    {
        if (objectToHit.TryGetComponent(out Hittable hittableObject))
        {
            hittableObject.TakeHit(damage, damageType, knockbackPower, gameObject.transform.position);
        }
    }
}
