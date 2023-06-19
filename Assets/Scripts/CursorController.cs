using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private Texture2D[] crosshairTextureArray;
    [SerializeField] private int frameCount;
    [SerializeField] private float recoilTime;
    [SerializeField] private Transform player;
    private int currentFrame = 0;
    private bool recoil = false;
    private float frameTimer;
    private float animChangeTimer;

    void Awake()
    {
        //Sets cursor to default crosshair
        Vector2 cursorOffset = new Vector2(crosshairTextureArray[0].width / 2, crosshairTextureArray[0].height / 2);
        Cursor.SetCursor(crosshairTextureArray[0], cursorOffset, CursorMode.ForceSoftware);
    }

    private void Update()
    {
        if (recoil)
        {
            HandleRecoil();
        }
    }

    private void HandleRecoil()
    {
        frameTimer += Time.deltaTime;
        if (frameTimer >= animChangeTimer)
        {
            animChangeTimer += (recoilTime / frameCount);
            currentFrame += 1;
            Cursor.SetCursor(crosshairTextureArray[currentFrame]
                            , new Vector2(crosshairTextureArray[currentFrame].width / 2
                            , crosshairTextureArray[currentFrame].height / 2), CursorMode.ForceSoftware);
        }

        if (frameTimer >= 0)
        {
            StopRecoilAnimation();
        }
    }

    public void StartRecoilAnimation()
    {
        frameTimer -= recoilTime;
        animChangeTimer += frameTimer + (recoilTime / frameCount);
        recoil = true;
    }

    private void StopRecoilAnimation()
    {
        frameTimer = 0;
        animChangeTimer = 0;
        currentFrame = 0;
        recoil = false;

        Vector2 cursorOffset = new Vector2(crosshairTextureArray[0].width / 2, crosshairTextureArray[0].height / 2);
        Cursor.SetCursor(crosshairTextureArray[0], cursorOffset, CursorMode.ForceSoftware);
    }
}