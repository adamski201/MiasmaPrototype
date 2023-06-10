using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPistol : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private float range = 10f, recoilTime = 1.5f;
    [SerializeField] private int damage = 20;
    [SerializeField] private int knockbackPower = 2;
    private bool recoil = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Handles shooting logic using raycasts
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right, range);

        if (!recoil)
        {
            if (hit)
            {
                GameObject hitObject = hit.transform.gameObject;
                TryHitObject(hitObject);
            }

            recoil = true;
            Invoke("resetRecoil", recoilTime);
        }
    }

    void TryHitObject(GameObject objectToHit)
    {
        if (objectToHit.TryGetComponent(out Hittable hittableObject))
        {
            hittableObject.TakeHit(damage, knockbackPower, gameObject.transform.position);
        }
    }

    private void resetRecoil()
    {
        recoil = false;
    }
}
