using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Main : MonoBehaviour
{
    public delegate void ActionTap();
    public static event ActionTap onTap;

    /*
    * Get key input in Update to avoid input loss that happens in FixedUpdate
    * Send signal to FixedUpdate to do physics update
    */
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (onTap != null)
            {
                onTap();
            }
        }
    }
}
