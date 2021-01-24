using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LockCursor();
    }

    void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void unLockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
