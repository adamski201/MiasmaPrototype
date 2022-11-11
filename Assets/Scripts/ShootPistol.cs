using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPistol : MonoBehaviour
{
    public Transform firePoint;
    public float range = 10f;
    public int damage = 20;
    public float recoilTime = 1.5f;
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
                EnemyController zombie = hit.transform.GetComponent<EnemyController>();
                if (zombie)
                {
                    zombie.TakeDamage(damage);
                }
            }

            recoil = true;
            Invoke("resetRecoil", recoilTime);
        }
    }

    private void resetRecoil()
    {
        recoil = false;
    }
}
