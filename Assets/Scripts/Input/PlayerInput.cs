using UnityEngine;
using UnityEngine.Events;
using System;

public class PlayerInput : MonoBehaviour
{
    public UnityAction onClickEvent;
    public UnityEvent onInteractEvent;
    public IntEvent onNumKeyEvent;

    void Update()
    {
        GetMouseClickInput();
        GetNumberKeysInput();
        GetInteractKeyInput();
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

    private void GetNumberKeysInput()
    {
        if (Input.inputString != "")
        {
            int number;
            bool is_a_number = Int32.TryParse(Input.inputString, out number);
            if (is_a_number && number >= 0 && number < 10)
            {
                onNumKeyEvent?.Invoke(number);
            }
        }
    }

    private void GetInteractKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            onInteractEvent?.Invoke();
        }
    }
}
