using UnityEngine;

public class DropItems : MonoBehaviour
{
    [SerializeField] int dropCount = 3;
    [SerializeField] float spread = 0.7f;
    [SerializeField] GameObject droppedItem;

    public void DropResources()
    {
        while (dropCount > 0)
        {
            dropCount -= 1;

            Vector2 position = transform.position;
            position.x += spread * Random.value - spread / 2;
            position.y += spread * Random.value - spread / 2;
            GameObject drop = Instantiate(droppedItem);
            drop.transform.position = position;
        }
    }
}
