using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientVictim : MonoBehaviour
{
    public float speedMultiplaier;
    public Movement movement { get; private set; }
    public PatientVictimFrightened frightened { get; private set; }

    public PatientVictimBehaviour initialBehaviour;
    public Transform target;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        frightened = GetComponent<PatientVictimFrightened>();
    }

    public void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        gameObject.SetActive(true);
        movement.ResetState();
        movement.speedMultiplaier = speedMultiplaier;

        frightened.Disable();

        if (initialBehaviour != null)
        {
            initialBehaviour.Enable();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Paramedic"))
        {
            if(frightened.enabled)
            {
                FindObjectOfType<GameManager>().PatientVictimCatched(this);
            }
        }
    }
}
