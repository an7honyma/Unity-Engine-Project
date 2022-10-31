using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Texture2D defaultCursor;
    public Texture2D targetCursor;
    public Texture2D bulldozeCursor;

    private void Awake()
    {
        ChangeCursor(defaultCursor);
        // Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        if (SelectedUnits.onEnemyUnit)
        {
            ChangeCursor(targetCursor);
        }
        else if (BuildToggle.bulldozeMode)
        {
            ChangeCursor(bulldozeCursor);
        }
        else
        {
            ChangeCursor(defaultCursor);
        }
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        if (cursorType == defaultCursor)
        {
            Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Vector2 hotspot = new Vector2(cursorType.width/2, cursorType.height/2);
            Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
        }
    }
}
