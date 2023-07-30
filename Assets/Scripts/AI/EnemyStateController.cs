using UnityEngine;

public class EnemyStateController : MonoBehaviour
{
    IState currentState;
    public RoamState roamState = new();
    public ChaseState chaseState = new();
    public AttackState attackState = new();
    private MovePositionPathfinding pathfinding;
    private GameObject player;

    private void Awake()
    {
        pathfinding = GetComponent<MovePositionPathfinding>();
        player = GameObject.FindWithTag("Player");
    }

    private void Start()
    {
        ChangeState(roamState);
    }
    void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(this, player.transform.position);
        }
    }
    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        currentState.OnEnter(this, pathfinding);
    }

    public void TriggerOnHurt()
    {
        currentState.OnHurt(this);
    }
}