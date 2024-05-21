using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class CursorState
{
    public static bool cursorState = true;
    public static bool overrideLocked = false;
    public static void SetCursorState(bool _lock)
    {
        if(overrideLocked)
        {
            return;
        }
        
        cursorState = _lock;
        Cursor.lockState = _lock ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !_lock;
    }

    public static void OverrideLock(bool _lock)
    {
        overrideLocked = _lock;
    }

}
