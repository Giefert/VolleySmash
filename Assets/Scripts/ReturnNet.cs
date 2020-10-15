using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class ReturnNet : MonoBehaviour
{
    [SerializeField] private Volleyball _volleyball;
    [SerializeField] private Rigidbody2D _volleyballRb;
    [SerializeField] private Vector2 netCatchVelocity = new Vector2(2.0f, -1.0f);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _volleyball.UnlockBall();
        SetCatchVelocity(netCatchVelocity);
        Debug.Log("Ball height = " + _volleyballRb.transform.position.y);
    }

    private Vector2 SetCatchVelocity(Vector2 velocity)
    {
        _volleyballRb.velocity = velocity;
        return _volleyballRb.velocity;
    }
}
