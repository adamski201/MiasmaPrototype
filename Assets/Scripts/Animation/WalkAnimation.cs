using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnimation : MonoBehaviour
{
    private Animator animator;
    private MovePositionPathfinding movementController;
    private bool isMoving;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movementController = GetComponent<MovePositionPathfinding>();
    }

    void Update()
    {
        Vector2 movementDirection = movementController.GetMovementDirection();
        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);
    }
}
