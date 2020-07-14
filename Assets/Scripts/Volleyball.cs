using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
 **CHECKLIST**
 * Input
 * Reactions to boundaries and targets
 * Define states and trigger events
 */

public class Volleyball : MonoBehaviour
{
    // Check player state. There are 3 - Ball is reset, layed-up, or spiked.
    public enum State { Returned, Bounced, Spiked }
    private State state;
    public Vector2 bounceVelocity;
    public Vector2 spikeVelocity;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = State.Spiked;
        bounceVelocity = new Vector2(0.2f, 15.0f);
        spikeVelocity = new Vector2(25.0f, 0.5f);

        Main.onSignal += HitBall;
        Main.onTap += ChangeState;
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        // Change ball trajectory after receiving signal from Update

    }






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


    /* 
     * Do I need to seperate the physics action from the state update into two methods?
     * (one for Update and FixedUpdate each)
     */
    //private Vector2 BallVelocity(Vector2 velocity)
    //{
    //    return new Vector2 (0, 0);
    //}

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
                // Lock the ball
                // Call the delegate using event
                break;
        }
    }
    
    // Loops through the ball's states.
    private void ChangeState()
    {
        int currentState = Array.IndexOf(Enum.GetValues(state.GetType()), state); // this returns index value of state var
        Debug.Log("State: " + currentState);

        if (currentState >= 2)
        {
            currentState = 0;
        }
        else
        {
            currentState++;
        }

        State whatIsThis = (State)(Enum.GetValues(state.GetType())).GetValue(currentState); // this returns string value of state var
        Debug.Log("This is: " + whatIsThis);

        state = whatIsThis;
    }

    private void OnDisable()
    {
        Main.onTap -= HitBall;
    }
}
