using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RehabilitaCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Bloqueo de cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
