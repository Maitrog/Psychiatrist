using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Patient", menuName = "Patient")]
public class PatientObject : ScriptableObject
{

    public GameObject hair;
    public GameObject face;

    public Sex Sex;
    public string Name;
    public string Surname;
    public string Patronymic;
    public int Age;
    public double MaxToxic;
    public double Toxic;
    public double Speed;
    public List<DiseaseType> Diseases = new List<DiseaseType>();

    public void BecomeCurrent(Patient patient, GameObject newHair, GameObject newFace)
    {
        hair = newHair;
        face = newFace;

        Sex = patient.Sex;
        Name = patient.Name;
        Surname = patient.Surname;
        Patronymic = patient.Patronymic;
        Age = patient.Age;
        MaxToxic = patient.MaxToxic;
        Toxic = patient.Toxic;
        Speed = patient.Speed;

        Diseases = new List<DiseaseType>(patient.Diseases);
    }

    public void BecomeCurrent(PatientObject patient)
    {
        hair = patient.hair;
        face = patient.face;

        Sex = patient.Sex;
        Name = patient.Name;
        Surname = patient.Surname;
        Patronymic = patient.Patronymic;
        Age = patient.Age;
        MaxToxic = patient.MaxToxic;
        Toxic = patient.Toxic;
        Speed = patient.Speed;

        Diseases = new List<DiseaseType>(patient.Diseases);
    }

    public void Reset()
    {
        hair = null;
        face = null;

        Sex = Sex.MALE;
        Name = null;
        Surname = null;
        Patronymic = null;
        Age = 0;
        MaxToxic = 0;
        Toxic = 0;
        Speed = 0;
        Diseases = null;

    }
    public static bool operator ==(PatientObject patientSO, Patient patient)
    {
        return patientSO.Sex == patient.Sex && patientSO.Name == patient.Name && patientSO.Surname == patient.Surname &&
                patientSO.Patronymic == patient.Patronymic && patientSO.Age == patient.Age && patientSO.MaxToxic == patient.MaxToxic && 
                patientSO.Speed == patient.Speed && patientSO.Toxic == patient.Toxic;
    }
    public static bool operator !=(PatientObject patientSO, Patient patient)
    {
        return !(patientSO == patient);
    }
}