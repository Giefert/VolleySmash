using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public delegate void Tapped();
    public static event Tapped onTapped;

    // NEW TEST LINE 

    /*
    * Get key input in Update to avoid input loss that happens in FixedUpdate
    * Send signal to FixedUpdate to do physics update
    */
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(onTapped != null)
            {

            }
        }
    }
}
