using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

[DataContract]
public class ParamedicData
{
    [DataMember]
    public PhotoData photo;

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
        photo = new PhotoData(paramedic.photo);

        name = paramedic.Name;
        surname = paramedic.Surname;
        patronymic = paramedic.Patronymic;
        speed = paramedic.Speed;
        skills = new SkillData[paramedic.skills.Count];

        for(int i = 0; i < paramedic.skills.Count; i++)
        {
            skills[i] = new SkillData(paramedic.skills[i]);
        }
    }
}
