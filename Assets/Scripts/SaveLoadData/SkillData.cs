using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[DataContract]
public class SkillData
{
    [DataMember]
    public SkillLevel level;
    [DataMember]
    public SkillType type;
    [DataMember]
    public DiseaseType[] diseases;

    public SkillData(Skill skill)
    {
        level = skill.Level;
        type = skill.Type;
        diseases = new DiseaseType[skill.Diseases.Count];

        for (int i = 0; i < skill.Diseases.Count; i++)
        {
            diseases[i] = skill.Diseases[i];
        }
    }
}
