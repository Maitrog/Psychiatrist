using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[DataContract]
public class CurrentParamedicsData
{
    [DataMember]
    public ParamedicData[] currentParamedics;

    public CurrentParamedicsData()
    {
        currentParamedics = new ParamedicData[StaticCurrentParamedics.CurrentParamedic.Count];

        for(int i = 0; i < StaticCurrentParamedics.CurrentParamedic.Count; i++)
        {
            currentParamedics[i] = new ParamedicData(StaticCurrentParamedics.CurrentParamedic[i]);
        }
    }
}
