using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager: MonoSingleton<PlayerManager>
{

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            CursorState.SetCursorState(!CursorState.cursorState);
            CursorState.OverrideLock(!CursorState.overrideLocked);
        }
    }

}
