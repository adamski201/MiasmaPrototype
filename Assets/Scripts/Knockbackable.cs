using UnityEngine;
using Pathfinding;

public class Knockbackable : MonoBehaviour
{
    private Vector2 knockbackDirection;
    private AIPath aiPath;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        aiPath = GetComponent<AIPath>();
    }

    public void InflictKnockback(Vector3 inflicterPosition, float knockbackPower)
    {
        if (aiPath != null)
        {
            aiPath.Move(inflicterPosition * -1);
        }
        knockbackDirection = (transform.position - inflicterPosition).normalized;
        rb.AddForce(knockbackDirection * knockbackPower, ForceMode2D.Impulse);
    }
}
