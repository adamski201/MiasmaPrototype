using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlMovement : MonoBehaviour
{
    bool IsMoving
    {
        set {
            isMoving = value;

            if (isMoving)
            {
                rb.drag = moveDrag;
            } else
            {
                rb.drag = stopDrag;
            }
        }
    }

    [SerializeField] float moveDrag;
    [SerializeField] float stopDrag;
    private CharacterMovement characterMovement;
    private bool isMoving;
    private Rigidbody2D rb;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        characterMovement = GetComponent<CharacterMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 moveDirection = playerInput.GetMovementInput();

        if (moveDirection.x != 0 || moveDirection.y != 0)
        {
            IsMoving = true;
            characterMovement.Move(moveDirection);
        } else
        {
            IsMoving = false;
        }
    }
}
