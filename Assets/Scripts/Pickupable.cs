using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickupable : MonoBehaviour
{
    public UnityEvent onPickup;
    [SerializeField] public string itemName;

    public void PickUp()
    {
        onPickup?.Invoke();
    }
}
