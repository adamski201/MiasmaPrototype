using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootHitscan : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private float range = 10f, recoilTime = 0.3f;
    [SerializeField] private int damage = 20;
    [SerializeField] private int knockbackPower = 2;
    private bool recoil = false;
    [SerializeField] private UnityEvent shotFired;
    private float recoilTimer;

    void Update()
    {
        // Shoot upon mouse button click.
        if (!recoil)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }

        // Check if recoil period is over.
        if (recoil && Time.time >= recoilTimer)
        {
            recoil = false;
        }
    }

    private void Shoot()
    {
        // Handles shooting logic using raycasts
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right, range);

        if (hit)
        {
            GameObject hitObject = hit.transform.gameObject;
            TryHitObject(hitObject);
        }

        recoilTimer = Time.time + recoilTime;
        recoil = true;

        shotFired.Invoke();
    }

    void TryHitObject(GameObject objectToHit)
    {
        if (objectToHit.TryGetComponent(out Hittable hittableObject))
        {
            hittableObject.TakeHit(damage, knockbackPower, gameObject.transform.position);
        }
    }
}
