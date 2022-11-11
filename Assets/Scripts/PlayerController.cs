using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int health;
    private Rigidbody2D rb;
    private Vector2 direction;


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

        direction = new Vector2(directionX, directionY).normalized;
    }

    private void FixedUpdate() 
    {
        rb.velocity = direction * speed;   
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
        if (enemy)
        {
            TakeDamage(enemy.damage);
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
}
