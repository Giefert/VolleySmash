using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static event Action onTap;
    public static event Action onSignal;

    bool shouldSignal = false;

    private void Start()
    {
        
    }

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
                shouldSignal = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (shouldSignal == true)
        {
            if (onSignal != null)
            {
                onSignal();
                shouldSignal = false;
            }
        }

    }
}
