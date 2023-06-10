using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 3000;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 moveDirection)
    {
        rb.AddForce(speed * Time.fixedDeltaTime * moveDirection);
    }
}
