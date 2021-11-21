using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[DataContract]
public class PlayerData
{
    [DataMember]
    public CurrentParamedicsData currentParamedicsData;
    [DataMember]
    public CurrentPatientsData currentPatientsData;

    public PlayerData()
    {
        currentPatientsData = new CurrentPatientsData();
        currentParamedicsData = new CurrentParamedicsData();
    }
}
