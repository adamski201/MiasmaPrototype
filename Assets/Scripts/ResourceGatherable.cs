using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGatherable : MonoBehaviour
{
    [SerializeField] private float health = 30f;

    public virtual void Hit(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
