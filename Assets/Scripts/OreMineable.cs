using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreMineable : ToolHittable
{
    public override void Hit()
    {
        Destroy(gameObject);
    }
}
