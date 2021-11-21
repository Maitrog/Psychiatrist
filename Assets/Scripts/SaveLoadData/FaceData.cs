using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[DataContract]
public class FaceData
{
    [DataMember]
    public GameObject face;

    public FaceData(GameObject gameObject)
    {
        face = gameObject;
    }
}
