using UnityEngine;

public class ToolSwitcher : MonoBehaviour
{
    int selectedTool = 0;
    int lastSelectedTool;

    private void Start()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void SwitchTool(int keyNumber)
    {
        selectedTool = keyNumber - 1;
        if (selectedTool != lastSelectedTool)
        {
            int i = 0;
            foreach (Transform tool in transform)
            {
                if (i == selectedTool)
                {
                    tool.gameObject.SetActive(true);
                    lastSelectedTool = i;
                }
                else
                {
                    tool.gameObject.SetActive(false);
                }

                i++;
            }
        }
    }
}
