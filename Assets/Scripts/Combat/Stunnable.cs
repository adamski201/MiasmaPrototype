using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Stunnable : MonoBehaviour
{
    public void InflictStun(float stunTime)
    {
        if (gameObject.TryGetComponent(out IStunnable stunnable))
        {
            stunnable.StartHaltMovementCoroutine(stunTime);
        }
    }
}
