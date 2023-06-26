using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IState
{
    private MovePositionPathfinding pathfinding;
    private bool canPathfind = true;
    private float timer = 0f;
    private float timeToNextPathfind = 0.4f;
    private readonly float chaseSpeed = 3f;

    public void OnEnter(EnemyStateController sc, MovePositionPathfinding pathfinder)
    {
        pathfinding = pathfinder;
        pathfinding.SetSpeed(chaseSpeed);
    }

    public void UpdateState(EnemyStateController sc, Vector2 playerPosition)
    {
        if (canPathfind && Time.time > timer)
        {
            pathfinding.SetMovementPosition(playerPosition);
            timer = Time.time + timeToNextPathfind;
        }
    }

    public void OnHurt(EnemyStateController sc)
    {
        
    }

    public void OnExit(EnemyStateController sc)
    {
    }
}
