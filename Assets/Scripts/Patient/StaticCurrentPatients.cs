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

    public static void BecomeCurrent(CurrentPatientsData patientsData)
    {
        currentPatients.Clear();
        foreach(PatientData patient in patientsData.currentPatients)
        {
            currentPatients.Add(new PatientObject
            {
                hair = patient.hair.hair,
                face = patient.face.face,
                Sex = patient.sex,
                Name = patient.name,
                Surname = patient.surname,
                Patronymic = patient.patronymic,
                Toxic = patient.toxic,
                MaxToxic = patient.maxToxic,
                Speed = patient.speed,
                Age = patient.age,
                Diseases = new List<DiseaseType>(patient.diseases)
            });
        }

        selectedPatient.BecomeCurrent(new Patient
        {
            Sex = patientsData.selectedPatient.sex,
            Name = patientsData.selectedPatient.name,
            Surname = patientsData.selectedPatient.surname,
            Patronymic = patientsData.selectedPatient.patronymic,
            Toxic = patientsData.selectedPatient.toxic,
            MaxToxic = patientsData.selectedPatient.maxToxic,
            Speed = patientsData.selectedPatient.speed,
            Age = patientsData.selectedPatient.age,
            Diseases = new List<DiseaseType>(patientsData.selectedPatient.diseases)
        }, patientsData.selectedPatient.hair.hair, patientsData.selectedPatient.face.face);
    }
}
