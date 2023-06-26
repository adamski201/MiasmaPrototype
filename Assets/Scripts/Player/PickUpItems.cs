using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpItems : MonoBehaviour
{
    public UnityAction onPickup;
    private DynamicInventory inventory;

    private void Awake()
    {
        inventory = GetComponent<DynamicInventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Pickupable item))
        {
            inventory.AddItem(item.PickUp());
        }
    }
}
