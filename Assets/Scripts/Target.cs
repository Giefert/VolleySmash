using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Vector2 bouncebackVelocity = new Vector2(-20.0f, 1.0f);
    private float targetPosY = 0;
    private Vector2 targetNewPosition;
    // XXX private GameObject volleyball;
    [SerializeField] private Rigidbody2D volleyballRb;

    private void Start()
    {

    }

    // Changes target's position
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OK HIT");
        TargetBreak();
        BallBounce();
    }

    void TargetBreak()
    {
        targetPosY = Random.Range(-5.0f, 4.0f);
        targetNewPosition = new Vector2(transform.position.x, targetPosY);
        transform.position = targetNewPosition;
    }

    void BallBounce()
    {
        volleyballRb.velocity = bouncebackVelocity;

    }


    // TODO
    // 
    // Instantiate a target on game start instead of having it be part of the scene
    // Add an explosion effect on target break
}
