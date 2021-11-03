using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
