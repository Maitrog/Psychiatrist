using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[DataContract]
public class HairData
{
    [DataMember]
    public GameObject hair;

    public HairData(GameObject gameObject)
    {
        hair = gameObject;
    }
}
