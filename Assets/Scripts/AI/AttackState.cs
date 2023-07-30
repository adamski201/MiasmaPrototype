using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    private MovePositionPathfinding pathfinding;

    public void OnEnter(EnemyStateController sc, MovePositionPathfinding pathfinder)
    {
        pathfinding = pathfinder;
        pathfinding.SetSpeed(0);
    }

    public void UpdateState(EnemyStateController sc, Vector2 playerPosition)
    {

    }

    public void OnHurt(EnemyStateController sc)
    {

    }

    public void OnExit(EnemyStateController sc)
    {

    }
}
