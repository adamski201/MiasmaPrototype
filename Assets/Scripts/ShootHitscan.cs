using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootHitscan : MonoBehaviour
{
    [SerializeField] private UnityEvent shotFired;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float range = 10f, recoilTime = 0.3f;
    [SerializeField] private int damage = 20;
    [SerializeField] private int knockbackPower = 2;
    private bool recoil = false;
    private float recoilTimer;
    [SerializeField] private PlayerInput playerInput;

    private void OnEnable()
    {
        playerInput.onClickEvent += Shoot;
    }

    private void OnDisable()
    {
        playerInput.onClickEvent -= Shoot;
    }

    public void Shoot()
    {
        if (recoil && Time.time >= recoilTimer)
        {
            recoil = false;
        }

        // Check if recoil period is over
        if (!recoil)
        {
            // Shoot raycast and return hit object (or null)
            RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right, range);

            // If the ray hit an object, check if the object is Hittable
            if (hit)
            {
                GameObject hitObject = hit.transform.gameObject;
                TryHitObject(hitObject);
            }

            // Start recoil timer
            recoilTimer = Time.time + recoilTime;
            recoil = true;

            shotFired.Invoke();
        }
    }

    void TryHitObject(GameObject objectToHit)
    {
        if (objectToHit.TryGetComponent(out Hittable hittableObject))
        {
            hittableObject.TakeHit(damage, knockbackPower, gameObject.transform.position);
        }
    }
}
