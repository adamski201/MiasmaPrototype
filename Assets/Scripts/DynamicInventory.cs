using UnityEngine;
using System.Collections.Generic;

public class DynamicInventory : MonoBehaviour
{
    [SerializeField] private int maxItems = 10;
    [SerializeField] private List<ItemData> items = new();
    public bool AddItem(ItemData itemToAdd)
    {
        // Finds an empty slot if there is one
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                return true;
            }
        }
        // Adds a new item if the inventory has space
        if (items.Count < maxItems)
        {
            items.Add(itemToAdd);
            return true;
        }
        Debug.Log("No space in the inventory");
        return false;
    }
}