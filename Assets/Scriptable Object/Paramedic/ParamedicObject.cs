using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "New Paramedic", menuName = "Paramedic")]
public class ParamedicObject : ScriptableObject
{
    public GameObject photo;

    public Sex Sex;
    public string Name;
    public string Surname;
    public string Patronymic;
    public int Speed;
    public List<Skill> skills;


    public void BecomeCurrent(Paramedic paramedic, GameObject newPhoto)
    {
        photo = newPhoto;

        Sex = paramedic.Sex;
        Name = paramedic.Name;
        Surname = paramedic.Surname;
        Patronymic = paramedic.Patronymic;
        Speed = paramedic.Speed;
        skills = new List<Skill>(paramedic.skills);
    }

    public void Reset()
    {
        photo = null;

        Sex = Sex.MALE;
        Name = null;
        Surname = null;
        Patronymic = null;
        Speed = 0;
        skills = null;
    }
}
