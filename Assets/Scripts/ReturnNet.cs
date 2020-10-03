using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReturnNet : MonoBehaviour
{
    [SerializeField] private Volleyball _volleyball;
    [SerializeField] private Rigidbody2D _volleyballRb;
    [SerializeField] private Vector2 netCatchVelocity = new Vector2(2.0f, -1.0f);
    private Volleyball VolleyballScript;

    private void Start()
    {
       VolleyballScript = _volleyball.GetComponent<Volleyball>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        VolleyballScript.ballLocked = false;
        Debug.Log("Unlocked ball");
        _volleyballRb.velocity = netCatchVelocity;
    }
}
