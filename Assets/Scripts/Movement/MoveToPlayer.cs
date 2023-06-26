using UnityEngine;
using UnityEngine.Events;

public class MoveToPlayer : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float pickUpDistance = 3f;
    [SerializeField] private float speed = 5f;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > pickUpDistance)
        {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
