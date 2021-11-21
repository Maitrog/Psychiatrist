using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[DataContract]
public class PhotoData
{
    [DataMember]
    public GameObject photo;

    public PhotoData(GameObject gameObject)
    {
        photo = gameObject;
    }
}
