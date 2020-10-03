using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathbox : MonoBehaviour
{
    [SerializeField] private GameObject volleyball;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        volleyball.SetActive(false);
        Debug.Log("Restart");
    }

}
