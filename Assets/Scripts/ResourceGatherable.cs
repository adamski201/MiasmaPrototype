using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGatherable : MonoBehaviour
{
    [SerializeField] private float health = 30f;
    [SerializeField] GameObject droppedItem;
    [SerializeField] int dropCount = 3;
    [SerializeField] float spread = 0.7f;

    public virtual void Hit(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            DropItems();
        }
    }

    private void DropItems()
    {
        while (dropCount > 0)
        {
            dropCount -= 1;

            Vector2 position = transform.position;
            position.x += spread * Random.value - spread/2;
            position.y += spread * Random.value - spread/2;
            GameObject drop = Instantiate(droppedItem);
            drop.transform.position = position;
        }
        
    }
}
