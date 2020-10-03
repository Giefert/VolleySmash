using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Main : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Vector3 playerSpawnPos = new Vector3(-7.5f, -3.5f, 0.0f);
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 spawnTargetPos = new Vector3(7.66f, 0.0f, 0.0f);


    /*
     * Get key input in Update to avoid input loss that happens in FixedUpdate
     * Send signal to FixedUpdate to do physics update
     * 
     * Update 01/10/2020: Pretty sure this is done automatically based on the order of events in Unity
     */

    private void Update()
    {
        if (!player.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();
            }
        }
    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        player.transform.position = playerSpawnPos;
        player.SetActive(true);
    }


    #region Obsolete signal code
    //public static event Action onTap;
    //public static event Action onSignal;

    //bool shouldSignal = false;


    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        if (onTap != null)
    //        {
    //            onTap();
    //            shouldSignal = true;
    //        }
    //    }
    //    else if (player.activeSelf == false)
    //    {
    //        if (Input.GetKeyDown(KeyCode.R))
    //        {
    //            RestartGame();
    //        }
    //    }       
    //}

    //private void FixedUpdate()
    //{
    //    if (shouldSignal == true)
    //    {
    //        if (onSignal != null)
    //        {
    //            onSignal();
    //            shouldSignal = false;
    //        }
    //    }

    //}
    #endregion
}
