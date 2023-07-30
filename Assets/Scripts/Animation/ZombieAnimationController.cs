using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimationController : MonoBehaviour
{
    private Animator animator;
    private MovePositionPathfinding movementController;
    private Vector2 movementDirection;
    private SpriteRenderer sprite;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movementController = GetComponent<MovePositionPathfinding>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        HandleSpriteFlipping();

        movementDirection = movementController.GetMovementDirection();
        animator.SetFloat("Horizontal", movementDirection.x);
    }

    private void HandleSpriteFlipping()
    {
        if (movementDirection.x < 0)
        {
            sprite.flipX = true;
        }
        else if (movementDirection.x > 0)
        {
            sprite.flipX = false;
        }
    }
}
