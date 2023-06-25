using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MovePositionPathfinding : MonoBehaviour, IStunnable
{
    private AIPath aiPath;
    private GameObject player;

    private void Awake()
    {
        aiPath = GetComponent<AIPath>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    /*private void FixedUpdate()
    {
        SetMovementPosition(player.transform.position);
    }*/

    public void SetMovementPosition(Vector3 movePosition)
    {
        aiPath.destination = movePosition;
    }

    public void SetSpeed(float speed)
    {
        aiPath.maxSpeed = speed;
    }

    public void StartHaltMovementCoroutine(float duration)
    {
        StartCoroutine("HaltMovement", duration);
    }

    private IEnumerator HaltMovement(float duration)
    {
        aiPath.canMove = false;
        yield return new WaitForSeconds(duration);
        aiPath.canMove = true;

        yield return null;
    }
}
