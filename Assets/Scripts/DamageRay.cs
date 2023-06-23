using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageRay : MonoBehaviour, IShootable
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private float range;
    [SerializeField] private Hit hit;

    public void Launch()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right, range);
        Debug.DrawRay(firePoint.position, firePoint.right * range, Color.yellow, 0.1f);

        if (hit)
        {
            TryHitObject(hit.transform.gameObject);
        }
    }

    private void TryHitObject(GameObject objectToHit)
    {
        if (objectToHit.TryGetComponent(out Hittable hittableObject))
        {
            hit.knockbackSource = transform.position;
            hittableObject.TakeHit(hit);
        }
    }
}
