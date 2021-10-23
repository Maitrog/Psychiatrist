using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ParamedicCatcher paramedic;
    public PatientVictim patient;

    public PatientObject currentPatient;
    public ParamedicObject currentParamedic;

    public void Start()
    {
        NewGame();
    }

    private void ResetState()
    {
        patient.ResetState();
        paramedic.ResetState();
    }
    private void NewGame()
    {
        float spM = 1.0f - (float)(currentParamedic.Speed - currentPatient.Speed) / 16.0f;
        patient.speedMultiplaier = spM;
        patient.GetComponent<Movement>().speedMultiplaier = spM;
        paramedic.gameObject.SetActive(true);
        patient.gameObject.SetActive(true);
    }

    public void PatientVictimCatched(PatientVictim patient)
    {
        patient.gameObject.SetActive(false);
        GameOver();
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        paramedic.gameObject.SetActive(false);
        patient.gameObject.SetActive(false);
    }
}
