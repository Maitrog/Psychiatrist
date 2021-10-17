using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Patient", menuName = "Patient")]
public class PatientSO : ScriptableObject
{

    public GameObject hair;
    public GameObject face;
    public GameObject body;

    public Sex Sex;
    public string Name;
    public string Surname;
    public string Patronymic;
    public int Age;
    public double MaxToxic;
    public double Toxic;
    public double Speed;
    public List<Characters> Characters;

    public void BecomeCurrent(Patient patient, GameObject newHair, GameObject newFace, GameObject newBody)
    {
        hair = newHair;
        face = newFace;
        body = newBody;

        Sex = patient.Sex;
        Name = patient.Name;
        Surname = patient.Surname;
        Patronymic = patient.Patronymic;
        Age = patient.Age;
        MaxToxic = patient.MaxToxic;
        Toxic = patient.Toxic;
        Speed = patient.Speed;

        Characters = new List<Characters>(patient.Characters);
    }

    public static bool operator ==(PatientSO patientSO, Patient patient)
    {
        return patientSO.Sex == patient.Sex && patientSO.Name == patient.Name && patientSO.Surname == patient.Surname &&
                patientSO.Patronymic == patient.Patronymic && patientSO.Age == patient.Age && patientSO.MaxToxic == patient.MaxToxic && 
                patientSO.Speed == patient.Speed && patientSO.Toxic == patient.Toxic;
    }
    public static bool operator !=(PatientSO patientSO, Patient patient)
    {
        return !(patientSO == patient);
    }
}