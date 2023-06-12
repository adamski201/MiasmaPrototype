using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwitcher : MonoBehaviour
{
    int selectedTool = 0;
    int lastSelectedTool;

    private void Start() 
    {
        SelectTool();
    }

    private void Update() 
    {
        CheckKeyPress();

        if (selectedTool != lastSelectedTool)
        {
            SelectTool();
        }
    }

    private void SelectTool()
    {
        int i = 0;
        foreach (Transform tool in transform)
        {
            if (i == selectedTool)
            {
                tool.gameObject.SetActive(true);
                lastSelectedTool = i;
            } else 
            {
                tool.gameObject.SetActive(false);
            }

            i++;
        }
    }

    private void CheckKeyPress()
    {
        if (Input.GetKeyDown("1"))
        {
            selectedTool = 0;
        } 

        if (Input.GetKeyDown("2"))
        {
            selectedTool = 1;
        }

        if (Input.GetKeyDown("3"))
        {
            selectedTool = 2;
        }
    }
}
