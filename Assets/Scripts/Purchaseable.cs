using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Purchaseable : MonoBehaviour
{
    [SerializeField] private Cost[] costs;
    [SerializeField] private DynamicInventory inventory;
    public UnityEvent onPurchaseSuccess;

    public void AttemptPurchase()
    {
        foreach (Cost cost in costs)
        {
            if (inventory.FindItem(cost.item, cost.amount))
            {
                inventory.RemoveItem(cost.item, cost.amount);
                onPurchaseSuccess.Invoke();
            }
        }
    }
}
