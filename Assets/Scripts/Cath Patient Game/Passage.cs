using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passage : MonoBehaviour
{
    public Transform connection;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision");
        Vector3 position = other.transform.position;
        position.x = connection.position.x;
        position.y = connection.position.y;
        other.transform.position = position;
    }
}
