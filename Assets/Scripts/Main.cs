using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Main : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Vector3 playerSpawnPos = new Vector3(-7.5f, -3.5f, 0.0f);
    [SerializeField] private Vector2 playerResetVelocty = new Vector2(0.0f, 0.0f);
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 targetSpawnPos = new Vector3(7.66f, 0.0f, 0.0f);
    Color32 colorOrange = new Color32(255, 165, 0, 255);
    private int score;
    private int highscore;
    public TextMeshProUGUI scoreText;
    [SerializeField] private GameObject menu;
    [SerializeField] private PlayerInput _playerInput;


    /*
     * Get key input in Update to avoid input loss that happens in FixedUpdate
     * Send signal to FixedUpdate to do physics update
     * 
     * Update 01/10/2020: Pretty sure this is done automatically based on the order of events in Unity
     */

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
    }


    // Should player input be made into a game object in the scene?
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        } else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            EraseHighScore();
        }
    }


    // Restart game by reloading the scene
    public void RestartGame()
    {
        menu.SetActive(false);
        player.transform.position = playerSpawnPos;
        player.SetActive(false);
        //playerRb.velocity = playerResetVelocty;
        player.SetActive(true);
        target.transform.position = targetSpawnPos;
        score = 0;
        scoreText.color = Color.white;
        DisplayScore();
    }

    public void QuitGame()
    {
        menu.SetActive(false);
    }

    private void DisplayScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateScore()
    {
        score++;
        DisplayScore();

        if (score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", score);
            highscore = score;
            scoreText.color = colorOrange;
        }
    }

    public void ShowMenu_old()
    {
        // [wait for 1 second];
        menu.SetActive(true);
        
    }


    /* IN-PROGRESS
     * Trying to get the game over screen to appear after a 1 second delay.
     * 
     */
    private IEnumerator ShowMenu()
    {
        menu.SetActive(true);
        yield return null;
    }

    public void EraseHighScore()
    {
        PlayerPrefs.DeleteKey("Highscore");
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
