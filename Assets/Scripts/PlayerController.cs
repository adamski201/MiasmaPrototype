using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static int health;
    [SerializeField] private float speed, knockbackDuration, knockbackPower = 10;
    private Rigidbody2D rb;
    private Vector2 moveDirection, knockbackDirection;
    private bool knockedBack = false;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(directionX, directionY).normalized;
    }

    private void FixedUpdate() 
    {
        if (knockedBack)
        {
            rb.AddForce(knockbackDirection * knockbackPower, ForceMode2D.Impulse);
        } else 
        {
            rb.velocity = moveDirection * speed;  
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
        if (enemy)
        {
            TakeDamage(enemy.damage);
            StartCoroutine(Knockback(knockbackDuration, collision.transform));
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    private IEnumerator Knockback(float duration, Transform EnemyTransform)
    {
        knockbackDirection = (this.transform.position - EnemyTransform.position).normalized;

        knockedBack = true;
        yield return new WaitForSeconds(knockbackDuration);
        knockedBack = false;
        yield return null;
    } 
}
