using System.Collections.Generic;
using System;

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
            if (value != null)
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

    public static void BecomeCurrent(CurrentPatientsData patientsData, FacesDatabaseObject facesDatabase)
    {
        currentPatients.Clear();
        foreach (PatientData patient in patientsData.currentPatients)
        {
            currentPatients.Add(new PatientObject
            {
                hair = patient.sex == Sex.MALE ? facesDatabase.GetMaleHair[patient.hairId].gameObject : facesDatabase.GetFemaleHair[patient.hairId].gameObject,
                skin = facesDatabase.GetSkin[patient.skinId].gameObject,
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
        },
        patientsData.selectedPatient.sex == Sex.MALE ? facesDatabase.GetMaleHair[patientsData.selectedPatient.hairId].gameObject : facesDatabase.GetFemaleHair[patientsData.selectedPatient.hairId].gameObject,
        facesDatabase.GetSkin[patientsData.selectedPatient.skinId].gameObject);
    }
}
