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

    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        if (directionX != 0 || directionY != 0)
        {
            IsMoving = true;
            Vector2 moveDirection = new Vector2(directionX, directionY).normalized;
            characterMovement.Move(moveDirection);
        } else
        {
            IsMoving = false;
        }
    }
}
