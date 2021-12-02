using System.Collections.Generic;
using System;

public static class StaticCurrentParamedics
{
    private static List<ParamedicObject> currentParamedic = new List<ParamedicObject>();
    private static ParamedicObject selectedParamedic = new ParamedicObject();

    public static List<ParamedicObject> CurrentParamedic
    {
        get
        {
            return currentParamedic;
        }
        set
        {
            if (value != null)
            {
                currentParamedic = new List<ParamedicObject>(value);
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }

    public static ParamedicObject SelectedParamedic
    {
        get
        {
            return selectedParamedic;
        }
        set
        {
            if (value != null)
            {
                selectedParamedic.BecomeCurrent(value);
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }

    public static void BecomeCurrent(CurrentParamedicsData paramedicsData, PhotoDatabeseObject photoDatabese)
    {
        currentParamedic.Clear();
        foreach (ParamedicData paramedic in paramedicsData.currentParamedics)
        {
            List<Skill> newSkills = new List<Skill>();
            foreach (SkillData skill in paramedic.skills)
            {
                newSkills.Add(Skill.GetSkill(skill.type, skill.level));
            }

            currentParamedic.Add(new ParamedicObject
            {
                photo = photoDatabese.GetPhoto[paramedic.photoId].gameObject,
                Sex = paramedic.sex,
                Name = paramedic.name,
                Surname = paramedic.surname,
                Patronymic = paramedic.patronymic,
                Speed = paramedic.speed,
                skills = newSkills
            });
        }
    }
}
