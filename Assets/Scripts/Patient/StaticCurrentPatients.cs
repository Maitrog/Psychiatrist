using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class StaticCurrentPatients
{
    private static List<PatientObject> currentPatients = new List<PatientObject>();
    private static PatientObject selectedPatient = new PatientObject();

    public static List<PatientObject> CurrentPatients
    {
        get
        {
            return currentPatients;
        } 
        set
        {
            if(value != null)
            {
                currentPatients = new List<PatientObject>(value);
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }

    public static PatientObject SelectedPatient
    {
        get
        {
            return selectedPatient;
        }
        set
        {
            if (value != null)
            {
                selectedPatient.BecomeCurrent(value);
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
