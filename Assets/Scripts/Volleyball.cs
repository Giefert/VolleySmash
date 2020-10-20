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
    [SerializeField] private GameObject ballModel;
    public Vector3 spinRotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        SpinBall(spinRotation);
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
    // Simulate hitting the ball depending on it's state while applying spin
    private void HitBall()
    {
        switch (state)
        {
            case State.Returned:
                // Applies velocity to be mostly upwards
                rb.velocity = bounceVelocity;
                spinRotation = BallSpin(0.0f);
                Debug.Log(state);
                /* OR */
                //rb.AddForce(bounceVelocity, ForceMode2D.Impulse);
                break;
            case State.Bounced:
                // Applies velocity to be mostly headed rightwards
                rb.velocity = spikeVelocity;
                spinRotation = BallSpin(0.5f);
                Debug.Log(state);
                /* OR */
                //rb.AddForce(spikeVelocity, ForceMode2D.Impulse);
                break;
            case State.Spiked:
                // No actions
                spinRotation = BallSpin(3.0f);
                break;
        }
    }

    private Vector3 BallSpin(float spinSpeed)
    {
        //float spinSpeed;

        switch (state)
        {
            case State.Returned:
                spinRotation = SpinDirection(spinSpeed);
                Debug.Log("spinSpeed is : " + spinSpeed);
                break;
            case State.Bounced:
                spinRotation = SpinDirection(spinSpeed);
                Debug.Log("spinSpeed is : " + spinSpeed);
                break;
            case State.Spiked:
                spinRotation = SpinDirection(spinSpeed);
                Debug.Log("spinSpeed is : " + spinSpeed);
                break;
        }
        return spinRotation;
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
        //Debug.Log("This is: " + currentStateName);

        // Updates and returns the current state of the ball 
        state = currentStateName;
        return state;
    }

    public void SpinBall(Vector3 spinRotation)
    {
        ballModel.transform.Rotate(spinRotation);
    }

    private Vector3 SpinDirection(float speed)
    {
        var X_AXIS = SpinSpeed(-speed, speed);
        var Y_AXIS = SpinSpeed(-speed, speed);
        var Z_AXIS = SpinSpeed(-speed, speed);

        return new Vector3(Z_AXIS, Y_AXIS, Z_AXIS);
    }

    private float SpinSpeed(float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }

    public void UnlockBall()
    {
        state = State.Returned;
    }

    public void ResetBall()
    {
        var resetBall = new Vector3(0, 0, 0);
        spinRotation = resetBall;

        ballModel.transform.rotation = Quaternion.Euler(resetBall);
    }
    private void OnEnable()
    {
        state = State.Returned;
    }

    private void OnDisable()
    {
        ResetBall();
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
