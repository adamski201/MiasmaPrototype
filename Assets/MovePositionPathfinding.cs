using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MovePositionPathfinding : MonoBehaviour
{
    private AIPath aiPath;
    private GameObject player;

    private void Awake()
    {
        aiPath = GetComponent<AIPath>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        SetMovementPosition(player.transform.position);
    }

    public void SetMovementPosition(Vector3 movePosition)
    {
        aiPath.destination = movePosition;
    }
}
