using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Current Targets", menuName = "CurrentTargets")]
public class CurrentTargetsObject : ScriptableObject
{
    [SerializeField]
    public List<PatientObject> currentTarget;
    public List<bool> isReady = new List<bool> { true, true, true, true };
    [SerializeField]
    private int count;

    public int Count
    {
        get
        {
            return count;
        }
        set
        {
            count = value;
        }
    }


    public void AddPatient(int index, Patient patient, GameObject newHair, GameObject newSkin)
    {
        if (isReady[index])
        {
            currentTarget[index].BecomeCurrent(patient, newHair, newSkin);
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

