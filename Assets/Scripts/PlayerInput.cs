using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityAction onClickEvent;

    void Update()
    {
        GetMouseClickInput();
    }

    public Vector2 GetMovementInput()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        return new Vector2(directionX, directionY).normalized;
    }

    private void GetMouseClickInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onClickEvent?.Invoke();
        }
    }
}
