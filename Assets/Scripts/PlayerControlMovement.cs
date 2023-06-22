using UnityEngine;

public class PlayerControlMovement : MonoBehaviour
{
    [SerializeField] private float moveDrag;
    [SerializeField] private float stopDrag;
    private CharacterMovement characterMovement;
    private bool isMoving;
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

    private bool CheckIfMoving(Vector2 moveDirection)
    {
        return moveDirection.x != 0 || moveDirection.y != 0;
    }

    private bool CheckIfHasVelocity()
    {
        return rb.velocity.x != 0 || rb.velocity.y != 0;
    }
}
