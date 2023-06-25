using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    [SerializeField] float roamSpeed;
    [SerializeField] float maxDistance;
    [SerializeField] float minWaitTime, maxWaitTime;
    private Vector2 waypoint;
    private MovePositionPathfinding pathfinding;
    private bool idling = false;
    private bool timedOut = false;

    private void Awake()
    {
        pathfinding = GetComponent<MovePositionPathfinding>();
    }

    private void Start()
    {
        pathfinding.SetSpeed(roamSpeed);
        waypoint = CreateRandomDestination();
        pathfinding.SetMovementPosition(waypoint);
    }

    private void Update()
    {
        if (timedOut)
        {
            Debug.LogError("Potential Infinite Loop: Zombie roaming destination could not be found.");
            return;
        }

        if (!idling && Vector2.Distance(transform.position, waypoint) < 1)
        {
            idling = true;
            StartCoroutine(IdleThenMove());
        }
    }

    private Vector2 CreateRandomDestination()
    {
        Vector2 currentPosition = transform.position;
        float newX = Random.Range(-maxDistance, maxDistance);
        float newY = Random.Range(-maxDistance, maxDistance);
        Vector2 destination = new Vector2(newX, newY) + currentPosition;

        int timeoutCounter = 0;
        while (DestinationBlocked(transform.position, destination))
        {
            // Prevents a potential infinite loop if a destination cannot be found
            timeoutCounter++;
            if (timeoutCounter > 25)
            {
                timedOut = true;
                return currentPosition;
            }

            newX = Random.Range(-maxDistance, maxDistance);
            newY = Random.Range(-maxDistance, maxDistance);
            destination = new Vector2(newX, newY) + currentPosition;
        }

        return destination;
    }

    IEnumerator IdleThenMove()
    {
        float idleTimer = Random.Range(minWaitTime, maxWaitTime);
        yield return new WaitForSeconds(idleTimer);

        waypoint = CreateRandomDestination();

        pathfinding.SetMovementPosition(waypoint);
        idling = false;
        yield return null;
    }

    private bool DestinationBlocked(Vector2 position, Vector2 destination)
    {
        float rayDistance = Vector2.Distance(position, destination);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (destination-position).normalized, rayDistance);
        //Debug.DrawRay(transform.position, (destination - position).normalized * rayDistance, Color.yellow, 0.4f);
        
        if (hit)
        {
            return true;
        }

        return false;
    }

}
