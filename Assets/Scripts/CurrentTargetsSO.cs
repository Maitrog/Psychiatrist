using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Current Targets", menuName = "CurrentTargets")]
public class CurrentTargetsSO : ScriptableObject
{
    public List<PatientSO> currentTarget;
    public List<bool> isReady = new List<bool> { true, true, true, true };
    public int count;

    public void AddPatient(int index, Patient patient, GameObject newHair, GameObject newFace, GameObject newBody)
    {
        if (isReady[index])
        {
            currentTarget[index].BecomeCurrent(patient, newHair, newFace, newBody);
            isReady[index] = false;
            count++;
        }
    }

    public void DeletePatient(int index)
    {
        if (index < 4)
        {
            isReady[index] = true;
            count--;
        }
    }
}

