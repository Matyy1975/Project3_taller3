using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    [SerializeField] private CursorType  defaultCursor,cursor;

    /*private void OnMouseEnter()
    {
        Cursor.SetCursor(cursor.CursorTexture, cursor.cursorhotspot, CursorMode.Auto);
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(defaultCursor.CursorTexture, cursor.cursorhotspot, CursorMode.Auto);

    }
    */
    private void Start()
    {
        On_cursor_default();
    }
    public void On_cursor_default()
    {
        Cursor.SetCursor(defaultCursor.cursorTexture, defaultCursor.cursorhotspot, CursorMode.Auto);
    }
    public void On_cursor_texture()
    {
        Cursor.SetCursor(cursor.cursorTexture, cursor.cursorhotspot, CursorMode.Auto);

    }
}
