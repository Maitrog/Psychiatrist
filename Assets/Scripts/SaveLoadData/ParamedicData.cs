using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

[DataContract]
[System.Serializable]
public class ParamedicData
{
    [DataMember]
    public int photoId;

    [DataMember]
    public Sex sex;
    [DataMember]
    public string name;
    [DataMember]
    public string surname;
    [DataMember]
    public string patronymic;
    [DataMember]
    public int speed;
    [DataMember]
    public SkillData[] skills;

    public ParamedicData(ParamedicObject paramedic)
    {
        photoId = paramedic.photo != null ? paramedic.photo.GetComponent<Photo>().Id : 0;

        name = paramedic.Name;
        surname = paramedic.Surname;
        patronymic = paramedic.Patronymic;
        sex = paramedic.Sex;
        speed = paramedic.Speed;
        skills = new SkillData[paramedic.skills.Count];

        for (int i = 0; i < paramedic.skills.Count; i++)
        {
            skills[i] = new SkillData(paramedic.skills[i]);
        }
    }
}
