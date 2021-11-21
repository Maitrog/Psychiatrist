using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[DataContract]
public class CurrentPatientsData
{
    [DataMember]
    public PatientData[] currentPatients;
    [DataMember]
    public PatientData selectedPatient;

    public CurrentPatientsData()
    {
        selectedPatient = new PatientData(StaticCurrentPatients.SelectedPatient);
        currentPatients = new PatientData[StaticCurrentPatients.CurrentPatients.Count];

        for (int i = 0; i < StaticCurrentPatients.CurrentPatients.Count; i++)
        {
            currentPatients[i] = new PatientData(StaticCurrentPatients.CurrentPatients[i]);
        }
    }
}
