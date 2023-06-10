using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private int knockbackPower = 30;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidedObject = collision.gameObject;
        TryHitObject(collidedObject);
    }

    void TryHitObject(GameObject objectToHit)
    {
        if (objectToHit.TryGetComponent(out Hittable hittableObject))
        {
            hittableObject.TakeHit(damage, knockbackPower, gameObject.transform.position);
        }
    }
}
