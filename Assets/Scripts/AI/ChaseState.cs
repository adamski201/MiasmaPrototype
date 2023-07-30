using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IState
{
    private MovePositionPathfinding pathfinding;
    private float timer = 0f;
    private float timeToNextPathfind = 0.4f;
    private readonly float chaseSpeed = 1f;
    private readonly float attackDistance = 1.5f;

    public void OnEnter(EnemyStateController sc, MovePositionPathfinding pathfinder)
    {
        pathfinding = pathfinder;
        pathfinding.SetSpeed(chaseSpeed);
    }

    public void UpdateState(EnemyStateController sc, Vector2 playerPosition)
    {
        if (Time.time > timer)
        {
            pathfinding.SetMovementPosition(playerPosition);
            timer = Time.time + timeToNextPathfind;
        }

        Debug.Log(Vector2.Distance(sc.transform.position, playerPosition));
        if (Vector2.Distance(sc.transform.position, playerPosition) < attackDistance)
        {
            sc.ChangeState(sc.attackState);
        }
    }

    public void OnHurt(EnemyStateController sc)
    {
        
    }

    public void OnExit(EnemyStateController sc)
    {
    }
}
