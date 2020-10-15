using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Vector2 bouncebackVelocity = new Vector2(-30.0f, 2.0f);
    private float targetPosY = 0;
    private Vector2 targetNewPosition;
    [SerializeField] private Rigidbody2D _volleyballRb;
    [SerializeField] private Main _main;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("OK HIT");
        TargetBreak();
        BallBounce();
        _main.UpdateScore();
        Debug.Log("Ball height = " + _volleyballRb.transform.position.y);
        
    }

    void TargetBreak()
    {
        targetPosY = Random.Range(-5.0f, 4.0f);
        targetNewPosition = new Vector2(transform.position.x, targetPosY);
        transform.position = targetNewPosition;
    }

    void BallBounce()
    {
        _volleyballRb.velocity = bouncebackVelocity;

    }


    // TODO
    // 
    // Instantiate a target on game start instead of having it be part of the scene
    // Add an explosion effect on target break
}
