using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static int oreCount = 0;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void GainResource(string resource)
    {
        if (resource == "Ore Nugget")
        {
            oreCount++;
        }
    }
}
