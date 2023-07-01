using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private UnityEvent onSwing;

    private void OnEnable()
    {
        playerInput.onClickEvent += Swing;
    }

    private void OnDisable()
    {
        playerInput.onClickEvent -= Swing;
    }

    private void Swing()
    {
        onSwing.Invoke();
    }
}
