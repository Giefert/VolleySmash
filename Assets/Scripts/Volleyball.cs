using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Volleyball : MonoBehaviour
{
    // Check player state. There are 3 - Ball is reset, layed-up, or spiked.
    public enum State { Returned, Bounced, Spiked }
    private State state;
    [SerializeField] private Vector2 bounceVelocity = new Vector2(0.2f, 15.0f);
    [SerializeField] private Vector2 spikeVelocity = new Vector2(40.0f, -1.0f);
    private Rigidbody2D rb;
    [SerializeField] private Main _main;
    private bool bBallLocked = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (state != State.Spiked)
        {
            if (Input.GetMouseButtonDown(0))
            {
                HitBall();
                ChangeState();
            }
        }
    }
    

    #region HitBall summary
    ///<summary>
    /// BallTap() behavior.
    /// Starting state
    /// behavior: Can do the first tap to have the ball bounce up for preparation.
    /// movement: Moves slightly forward when it launches upwards, in a natural parabola.
    /// 
    /// Second state
    /// behavior: Can do the second tap to spike the ball.
    /// movement: Shoots forward at highspeed towards the right side of screen.
    /// 
    /// Final state
    /// behavior: Ball is "locked" and will not be reset until it is returned to the "safety net".
    /// movement: Returns to the "safety net" if it collides with a target.
    /// 
    /// Return to starting state
    /// </summary>
    #endregion // TITLE
    // Simulate hitting the ball depending on it's state
    private void HitBall()
    {
        switch (state)
        {
            case State.Returned:
                // Change velocity to be mostly upwards
                rb.velocity = bounceVelocity;
                /* OR */
                //rb.AddForce(bounceVelocity, ForceMode2D.Impulse);
                break;
            case State.Bounced:
                // Change velocity to be mostly headed rightwards
                rb.velocity = spikeVelocity;
                /* OR */
                //rb.AddForce(spikeVelocity, ForceMode2D.Impulse);
                break;
            case State.Spiked:
                // Do nothing
                break;
        }
    }

    // Loops through the ball's states.
    private State ChangeState()
    {
        var enumArray = Enum.GetValues(state.GetType());
        int arraySize = enumArray.Length;
        //int arraySize = 2;

        // Debug message (State: #)
        int currentStateNum = Array.IndexOf(enumArray, state); // To allow incrementing through the index this returns the current index value of state enum
        //Debug.Log("State: " + currentStateNum);

        // Loop ball states in order 0, 1, 2, 0...
        currentStateNum = ++currentStateNum % arraySize;

        // Debug message (This is CURRENT_STATE)
        State currentStateName = (State)enumArray.GetValue(currentStateNum); // this returns string value of state var
        Debug.Log("This is: " + currentStateName);

        // Updates and returns the current state of the ball 
        state = currentStateName;
        return state;
    }

    public void UnlockBall()
    {
        state = State.Returned;
    }

    private void OnEnable()
    {
        state = State.Returned;
    }

    private void OnDisable()
    {
        //_main.StartCoroutine("ShowMenu", 0.5f);
        _main.ShowMenu_old();
    }



    /* Do I need this code?
     * 
     * 
        public void SetBallState(State newState)
        {
            state = newState;
        }

        public State GetBallState()
        {
            return state;
        }
    *
    */

    #region Obsolete signal code
    //private void Start()
    //{
    //Main.onSignal += HitBall;
    //Main.onTap += ChangeState;
    //}


    //private void OnDisable()
    //{
    //Main.onTap -= HitBall;
    //}
    #endregion
}
