using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    [SerializeField] private Transform aimPoint;
    [SerializeField] private float range = 1f, damage = 10f, waitTime = 0.5f;
    private bool wait = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }

    private void UseTool()
    {
        RaycastHit2D hit = Physics2D.Raycast(aimPoint.position, aimPoint.right, range);

        if (!wait)
        {
            if (hit)
            {
                OreMineable ore = hit.transform.GetComponent<OreMineable>();
                if (ore)
                {
                    ore.Hit(damage);
                    wait = true;
                    Invoke("resetWaitTime", waitTime);
                }
            }
        }
    }

    private void resetWaitTime()
    {
        wait = false;
    }
}
