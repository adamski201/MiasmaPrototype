using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private UnityEvent onSwing;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Hit hit;
    private Transform enemyTransform;
    private bool enemyInRange = false;
    private bool lockingOn = false;
    private float lockOnGap = 1.3f;
    private float lockOnPower = 10f;
    private float attackTimer = 0f;
    private float attackDuration = 0.5f;
    private Vector2 lockOnDirection;
    

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
        if (enemyInRange && Time.time >= attackTimer)
        {
            StartCoroutine(Attack());

            attackTimer = Time.time + attackDuration;
            lockingOn = true;
        }
    }

    private void FixedUpdate()
    {
        HandleMoveToEnemy();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyInRange = true;
            enemyTransform = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyInRange = false;
            enemyTransform = null;
        }
    }

    private void HandleMoveToEnemy()
    {
        if (lockingOn && enemyInRange)
        {
            // Get direction from player to enemy
            lockOnDirection = (enemyTransform.position - transform.position).normalized;

            // Check if distance between enemy and player is larger than the lock on gap
            if (Vector2.Distance(transform.position, enemyTransform.position) > lockOnGap)
            {
                // If it is, then move the player towards the enemy
                rb.AddForce(lockOnDirection * lockOnPower, ForceMode2D.Impulse);
            }
            else
            {
                // Else the player is within range of the enemy
                lockingOn = false;
            }
        }
    }

    IEnumerator Attack()
    {
        Debug.Log("Starting Attack");
        yield return new WaitForSeconds(0.3f);
        Debug.Log("Hit Enemy");
        if (enemyTransform.gameObject.TryGetComponent<Hittable>(out Hittable hittableObject))
        {
            hittableObject.TakeHit(hit);
        }
    }
}
