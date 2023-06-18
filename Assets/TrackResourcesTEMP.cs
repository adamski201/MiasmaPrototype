using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrackResourcesTEMP : MonoBehaviour
{
    private int woodCounter;
    private int oreCounter;
    [SerializeField] private TextMeshProUGUI woodUI;
    [SerializeField] private TextMeshProUGUI oreUI;

    public void AddResource(string name)
    {
        if (name == "Log")
        {
            woodCounter++;
            UpdateInventory();
        } else if (name == "Ore Nugget")
        {
            oreCounter++;
            UpdateInventory();
        }
    }

    private void UpdateInventory()
    {
        woodUI.text = "Wood: " + woodCounter;
        oreUI.text = "Ore: " + oreCounter;
    }
}
