using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private PlayerInput input;
    private Animator animator;
    private SpriteRenderer sprite;
    private PlayerControlMovement playerMovement;

    private Vector2 movementDirection;
    private Vector2 movementDirectionCached;

    private readonly float attackAnimationTimer = 0.8f;
    private bool inAttack = false;
    private float flipTimer = 0f;
    private Vector3 aimDirection;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerControlMovement>();
    }

    private void OnEnable()
    {
        input.onClickEvent += TriggerAttackAnimation;
    }

    private void OnDisable()
    {
        input.onClickEvent -= TriggerAttackAnimation;
    }

    private void Update()
    {
        HandleMovementAnimation();
        HandleSpriteFlipping();

        Vector3 mousePosition = input.GetMousePosition();
        aimDirection = (mousePosition - transform.position).normalized;

        if (inAttack && Time.time >= flipTimer)
        {
            inAttack = false;
        }
    }

    private void HandleMovementAnimation()
    {
        movementDirection = input.GetMovementInput();

        // If stationary
        if (movementDirection == Vector2.zero)
        {
            animator.SetFloat("Horizontal", movementDirectionCached.x);
            animator.SetFloat("Vertical", movementDirectionCached.y);

            animator.SetBool("IsMoving", false);

        }
        // If moving
        else
        {
            animator.SetBool("IsMoving", true);
            movementDirectionCached = movementDirection;

            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
        }
    }

    private void HandleSpriteFlipping()
    {
        if (!inAttack)
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

    private void TriggerAttackAnimation()
    {
        if (!inAttack)
        {
            // Get mouse position and set blend tree values to the direction of cursor
            animator.SetFloat("MouseHorizontal", aimDirection.x);
            animator.SetFloat("MouseVertical", aimDirection.y);

            flipTimer = Time.time + attackAnimationTimer;
            inAttack = true;

            if (aimDirection.x > 0f)
            {
                sprite.flipX = false;
            }
            else if (aimDirection.x < 0f)
            {
                sprite.flipX = true;
            }

            animator.SetTrigger("Attack");
            playerMovement.StartHaltMovementCoroutine(attackAnimationTimer);
        }
    }
}
