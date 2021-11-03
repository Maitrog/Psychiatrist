using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paramedic : MonoBehaviour
{
    public Photo photo;

    public Sex Sex;
    public string Name;
    public string Surname;
    public string Patronymic;
    public int Speed;
    public List<Skill> skills = new List<Skill>();
}

[System.Serializable]
public class Skill
{
    public SkillLevel Level { get; private set; }
    public SkillType Type { get; private set; }
    public List<DiseaseType> Diseases { get; private set; }

    private Skill() { }

    public static Skill GetSkill(SkillType type, SkillLevel level)
    {
        Skill skill = new Skill { Type = type, Level = level, Diseases = new List<DiseaseType>() };
        switch (type)
        {
            case SkillType.DIPLOMACY:
                switch (level)
                {
                    case SkillLevel.LOWEST:
                        skill.Diseases.AddRange(new List<DiseaseType> { DiseaseType.SOCIOPATHY, DiseaseType.DEPRESSION, DiseaseType.VANITY });
                        break;
                    case SkillLevel.HIGH:
                        skill.Diseases.AddRange(new List<DiseaseType> { DiseaseType.PSYCHOSIS, DiseaseType.RAVE });
                        goto case SkillLevel.MIDDLE;
                    case SkillLevel.MIDDLE:
                        skill.Diseases.AddRange(new List<DiseaseType> { DiseaseType.GREED, DiseaseType.VANITY, DiseaseType.HALLUCINATIONS });
                        goto case SkillLevel.LOW;
                    case SkillLevel.LOW:
                        skill.Diseases.AddRange(new List<DiseaseType> { DiseaseType.DEPRESSION });
                        break;
                }
                break;
            case SkillType.WILL:
                switch (level)
                {
                    case SkillLevel.LOWEST:
                        skill.Diseases.AddRange(new List<DiseaseType> { DiseaseType.ANGER, DiseaseType.SOCIOPATHY, DiseaseType.PSYCHOSIS, DiseaseType.VANITY });
                        break;
                    case SkillLevel.HIGH:
                        skill.Diseases.AddRange(new List<DiseaseType> { DiseaseType.PSYCHOSIS, DiseaseType.SOCIOPATHY });
                        goto case SkillLevel.MIDDLE;
                    case SkillLevel.MIDDLE:
                        skill.Diseases.AddRange(new List<DiseaseType> { DiseaseType.ANGER, DiseaseType.RAVE });
                        goto case SkillLevel.LOW;
                    case SkillLevel.LOW:
                        skill.Diseases.AddRange(new List<DiseaseType> { DiseaseType.VANITY, DiseaseType.GREED });
                        break;
                }
                break;
            case SkillType.PHYSICAL:
                switch (level)
                {
                    case SkillLevel.LOWEST:
                        skill.Diseases.AddRange(new List<DiseaseType> { DiseaseType.ANGER, DiseaseType.PSYCHOSIS, DiseaseType.SELF_TORTURE });
                        break;
                    case SkillLevel.HIGH:
                        skill.Diseases.AddRange(new List<DiseaseType> { DiseaseType.ANGER});
                        goto case SkillLevel.MIDDLE;
                    case SkillLevel.MIDDLE:
                        skill.Diseases.AddRange(new List<DiseaseType> { DiseaseType.PSYCHOSIS });
                        goto case SkillLevel.LOW;
                    case SkillLevel.LOW:
                        skill.Diseases.AddRange(new List<DiseaseType> { DiseaseType.SELF_TORTURE });
                        break;
                }
                break;
            case SkillType.EMPATHY:
                switch (level)
                {
                    case SkillLevel.LOWEST:
                        skill.Diseases.AddRange(new List<DiseaseType> { DiseaseType.PARANOIA, DiseaseType.DEPRESSION, DiseaseType.PSYCHOSIS });
                        break;
                    case SkillLevel.HIGH:
                        skill.Diseases.AddRange(new List<DiseaseType> { DiseaseType.PSYCHOSIS });
                        goto case SkillLevel.MIDDLE;
                    case SkillLevel.MIDDLE:
                        skill.Diseases.AddRange(new List<DiseaseType> { DiseaseType.PARANOIA, DiseaseType.HALLUCINATIONS });
                        goto case SkillLevel.LOW;
                    case SkillLevel.LOW:
                        skill.Diseases.AddRange(new List<DiseaseType> { DiseaseType.DEPRESSION });
                        break;
                }
                break;
            case SkillType.ADDITIONAL:
                skill.Diseases.AddRange(new List<DiseaseType> { DiseaseType.ANGER, DiseaseType.SELF_TORTURE });
                break;
        }
        return skill;
    }
}

[System.Serializable]
public enum SkillLevel
{
    LOWEST,
    LOW,
    MIDDLE,
    HIGH
}

[System.Serializable]
public enum SkillType
{
    DIPLOMACY,
    WILL,
    PHYSICAL,
    EMPATHY,
    ADDITIONAL
}