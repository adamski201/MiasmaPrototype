using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float pickUpDistance = 3f;
    [SerializeField] private float speed = 5f;
    private PlayerController pc;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }

    private void Update() 
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > pickUpDistance)
        {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        if (distance < 0.1f)
        {
            Destroy(gameObject);
            pc.GainResource(gameObject.name);
        }
    }
}
