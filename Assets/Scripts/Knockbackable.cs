using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockbackable : MonoBehaviour
{
    private Vector2 knockbackDirection;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void InflictKnockback(Vector3 inflicterPosition, float knockbackPower)
    {
        knockbackDirection = (transform.position - inflicterPosition).normalized;
        rb.AddForce(knockbackDirection * knockbackPower, ForceMode2D.Impulse);
    }
}
