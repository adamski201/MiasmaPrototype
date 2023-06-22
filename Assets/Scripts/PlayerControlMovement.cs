using UnityEngine;
using System.Collections;

public class PlayerControlMovement : MonoBehaviour, IStunnable
{
    [SerializeField] private float moveDrag;
    [SerializeField] private float stopDrag;
    private CharacterMovement characterMovement;
    private bool isMoving;
    private bool canMove = true;
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    bool IsMoving
    {
        set
        {
            isMoving = value;

            if (!isMoving && CheckIfHasVelocity())
            {
                rb.drag = stopDrag;
            }
            else
            {
                rb.drag = moveDrag;
            }
        }
    }

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        characterMovement = GetComponent<CharacterMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {   
        if (canMove)
        {
            Vector2 moveDirection = playerInput.GetMovementInput();

            if (CheckIfMoving(moveDirection))
            {
                IsMoving = true;
                characterMovement.Move(moveDirection);
            }
            else
            {
                IsMoving = false;
            }
        }
    }

    private bool CheckIfMoving(Vector2 moveDirection)
    {
        return moveDirection.x != 0 || moveDirection.y != 0;
    }

    private bool CheckIfHasVelocity()
    {
        return rb.velocity.x != 0 || rb.velocity.y != 0;
    }

    public void StartHaltMovementCoroutine(float duration)
    {
        StartCoroutine("HaltMovement", duration);
    }

    private IEnumerator HaltMovement(float duration)
    {
        canMove = false;
        yield return new WaitForSeconds(duration);
        canMove = true;

        yield return null;
    }
}
