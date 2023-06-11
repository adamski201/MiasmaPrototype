using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private Texture2D[] crosshairTextureArray;
    [SerializeField] private int frameCount;
    [SerializeField] private float frameRate;
    private int currentFrame;
    private float frameTimer;

    void Awake()
    {
        //set the cursor origin to its centre. (default is upper left corner)
        Vector2 cursorOffset = new Vector2(crosshairTextureArray[0].width / 2, crosshairTextureArray[0].height / 2);

        //Sets the cursor to the Crosshair sprite with given offset 
        Cursor.SetCursor(crosshairTextureArray[0], cursorOffset, CursorMode.ForceSoftware);
    }

    private void Update()
    {
        frameTimer -= Time.deltaTime;
        if (frameTimer <= 0f)
        {
            frameTimer += frameRate;
            currentFrame = (currentFrame + 1) % frameCount;
            Cursor.SetCursor(crosshairTextureArray[currentFrame]
                            , new Vector2(crosshairTextureArray[currentFrame].width / 2
                            , crosshairTextureArray[currentFrame].height), CursorMode.ForceSoftware);
        }
    }
}
