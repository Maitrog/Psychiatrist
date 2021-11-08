using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchPatient : MonoBehaviour
{
    public GameObject searchPanel;
    public Patient patient;
    public CurrentTargetsObject currentTargets;

    public void Catch()
    {
        for(int i = 0; i < currentTargets.currentTarget.Count; i++)
        { 
            if(currentTargets.currentTarget[i] == patient)
            {
                StaticCurrentPatients.SelectedPatient.BecomeCurrent(patient, currentTargets.currentTarget[i].hair, currentTargets.currentTarget[i].face, currentTargets.currentTarget[i].body);
                currentTargets.DeletePatient(i);
                StaticCurrentPatients.CurrentPatients = currentTargets.currentTarget;

                var characterGameObject = searchPanel.transform.GetChild(i).GetChild(0).gameObject;
                Patient renderedPatient = characterGameObject.GetComponent<Patient>();
                Destroy(renderedPatient.transform.GetChild(0).gameObject);
                Destroy(renderedPatient.transform.GetChild(1).gameObject);
                Destroy(renderedPatient.transform.GetChild(2).gameObject);
            }
        }
    }
}
