using UnityEngine;

public interface IState
{
    public void OnEnter(EnemyStateController controller, MovePositionPathfinding pathfinding);
    public void UpdateState(EnemyStateController controller, Vector2 playerPosition);
    public void OnHurt(EnemyStateController controller);
    public void OnExit(EnemyStateController controller);
}