using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamState : IState
{
    private readonly float roamSpeed = 1f;
    private readonly float maxDistance = 3f;
    private readonly float minWaitTime = 0.5f, maxWaitTime = 4.5f;
    private Vector2 waypoint;
    private MovePositionPathfinding pathfinding;
    private bool idling = true;
    private bool timedOut = false;
    private Vector2 currentPosition;
    private float idleTimer;

    public void OnEnter(EnemyStateController sc, MovePositionPathfinding pathfinder)
    {
        pathfinding = pathfinder;

        // Change speed 
        pathfinding.SetSpeed(roamSpeed);
    }

    public void UpdateState(EnemyStateController sc, Vector2 playerPosition)
    {
        // Output timeout error if it has occurred
        if (timedOut)
        {
            Debug.LogError("Potential Infinite Loop: Zombie roaming destination could not be found.");
            return;
        }

        // Get current transform position
        currentPosition = sc.transform.position;

        // Check if idle period is over
        if (Time.time >= idleTimer)
        {
            if (idling)
            {
                // Creates random valid destination and moves to it
                waypoint = CreateRandomDestination(currentPosition);
                pathfinding.SetMovementPosition(waypoint);
            }

            idling = false;
        }

        // When entity reaches its destination, it idles for a random duration then finds a new destination
        if (!idling)
        {
            if (Vector2.Distance(currentPosition, waypoint) < 0.5f)
            {
                idling = true;
                float idleTime = Random.Range(minWaitTime, maxWaitTime);
                idleTimer = Time.time + idleTime;
            }
        }
    }

    public void OnHurt(EnemyStateController sc)
    {
        sc.ChangeState(sc.chaseState);
    }

    public void OnExit(EnemyStateController sc)
    {

    }

    private Vector2 CreateRandomDestination(Vector2 currentPosition)
    {
        // Create random destination in range
        float newX = Random.Range(-maxDistance, maxDistance);
        float newY = Random.Range(-maxDistance, maxDistance);
        Vector2 destination = new Vector2(newX, newY) + currentPosition;

        int timeoutCounter = 0;
        while (DestinationBlocked(currentPosition, destination))
        {
            // Prevents a potential infinite loop if a destination cannot be found
            timeoutCounter++;
            if (timeoutCounter > 25)
            {
                timedOut = true;
                return currentPosition;
            }
            // Keep finding new destination until it is not blocked (or timeout occurs)
            newX = Random.Range(-maxDistance, maxDistance);
            newY = Random.Range(-maxDistance, maxDistance);
            destination = new Vector2(newX, newY) + currentPosition;
        }

        return destination;
    }

    private bool DestinationBlocked(Vector2 position, Vector2 destination)
    {
        float rayDistance = Vector2.Distance(position, destination);
        RaycastHit2D hit = Physics2D.Raycast(currentPosition, (destination - position).normalized, rayDistance);
        //Debug.DrawRay(currentPosition, (destination - position).normalized * rayDistance, Color.yellow, 0.4f);

        return hit;
    }
}
