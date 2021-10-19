using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ParamedicCatcher paramedic;
    public GameObject patient;

    public PatientObject currentPatient;
    public ParamedicObject currentParamedic;

    public void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        paramedic.Speed = currentParamedic.Speed;
        paramedic.gameObject.SetActive(true);
        //patient.SetActive(true);
    }

    private void GameOver()
    {
        paramedic.gameObject.SetActive(false);
        patient.SetActive(false);
    }
}
