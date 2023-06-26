using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickupable : MonoBehaviour
{
    public UnityEvent onPickup;
    [SerializeField] private ItemData item;

    public ItemData PickUp()
    {
        onPickup?.Invoke();
        return item;
    }
}
