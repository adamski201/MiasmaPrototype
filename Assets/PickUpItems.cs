using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpItems : MonoBehaviour
{
    private TrackResourcesTEMP inventory;
    public UnityAction onPickup;

    private void Start()
    {
        inventory = GetComponentInChildren<TrackResourcesTEMP>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Pickupable item))
        {
            inventory.AddResource(item.itemName);
            item.PickUp();
        }
    }
}
