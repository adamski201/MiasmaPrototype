using UnityEngine;

public class CollisionAttack : MonoBehaviour
{
    [SerializeField] private Hit hit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedObject = collision.gameObject;
        TryHitObject(collidedObject);
    }

    void TryHitObject(GameObject objectToHit)
    {
        if (objectToHit.TryGetComponent(out Hittable hittableObject))
        {
            hit.knockbackSource = transform.position;
            hittableObject.TakeHit(hit);
        }
    }
}
