using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CorrectCreatingNPC
{
    //Patient tests
    [Test]
    public void WhenPatientCreated_ThenToxicLevelIsZero()
    {
        Patient patient = new Patient();
        Assert.AreEqual(patient.Toxic, 0);
    }

    [Test]
    public void WhenPatientCreated_ThenDiseasesIsEmpty()
    {
        Patient patient = new Patient();
        Assert.AreEqual(patient.Diseases.Count, 0);
    }

    //Paramedic tests
    [Test]
    public void WhenParamedicCreated_ThenSkillsIsEmpty()
    {
        Paramedic paramedic = new Paramedic();
        Assert.AreEqual(paramedic.skills.Count, 0);
    }

    //Disease tests
    [Test]
    public void WhenDiseaseCreatedWithAngerType_ThenDiseaseTypeIsAnger()
    {
        Disease disease = Disease.GetDisease(DiseaseType.ANGER);
        Assert.AreEqual(disease.Type, DiseaseType.ANGER);
    }
    [Test]
    public void WhenDiseaseCreatedWithAngerType_ThenDeviationsIsEqualToASpecificList()
    {
        Disease disease = Disease.GetDisease(DiseaseType.ANGER);
        Assert.AreEqual(disease.Deviations, new List<Deviation> { Deviation.UNCONTROLLED_AGGRESSION, Deviation.LUST_FOR_VIOLENCE });
    }

    [Test]
    public void WhenDiseaseCreatedWithBipolarDisorderType_ThenDiseaseTypeIsBipolarDisorder()
    {
        Disease disease = Disease.GetDisease(DiseaseType.BIPOLAR_DISORDER);
        Assert.AreEqual(disease.Type, DiseaseType.BIPOLAR_DISORDER);
    }
    [Test]
    public void WhenDiseaseCreatedWithBipolarDisorderType_ThenDeviationsIsEmpty()
    {
        Disease disease = Disease.GetDisease(DiseaseType.BIPOLAR_DISORDER);
        Assert.AreEqual(disease.Deviations.Count, 0);
    }

    [Test]
    public void WhenDiseaseCreatedWithDepressionType_ThenDiseaseTypeIsDepression()
    {
        Disease disease = Disease.GetDisease(DiseaseType.DEPRESSION);
        Assert.AreEqual(disease.Type, DiseaseType.DEPRESSION);
    }
    [Test]
    public void WhenDiseaseCreatedWithDepressionType_ThenDeviationsIsEqualToASpecificList()
    {
        Disease disease = Disease.GetDisease(DiseaseType.DEPRESSION);
        Assert.AreEqual(disease.Deviations, new List<Deviation> { Deviation.APATHY, Deviation.FATIGUE, Deviation.UNCERTAINTY, Deviation.SELF_FLAGELLATION });
    }

    [Test]
    public void WhenDiseaseCreatedWithGreedType_ThenDiseaseTypeIsGreed()
    {
        Disease disease = Disease.GetDisease(DiseaseType.GREED);
        Assert.AreEqual(disease.Type, DiseaseType.GREED);
    }
    [Test]
    public void WhenDiseaseCreatedWithGreedType_ThenDeviationsIsEqualToASpecificList()
    {
        Disease disease = Disease.GetDisease(DiseaseType.GREED);
        Assert.AreEqual(disease.Deviations, new List<Deviation> { Deviation.KLEPTOMANIA, Deviation.SELFISHNESS, Deviation.AVARICE });
    }

    [Test]
    public void WhenDiseaseCreatedWithHallucinationsType_ThenDiseaseTypeIsHallucinations()
    {
        Disease disease = Disease.GetDisease(DiseaseType.HALLUCINATIONS);
        Assert.AreEqual(disease.Type, DiseaseType.HALLUCINATIONS);
    }
    [Test]
    public void WhenDiseaseCreatedWithHallucinationsType_ThenDeviationsIsEmpty()
    {
        Disease disease = Disease.GetDisease(DiseaseType.HALLUCINATIONS);
        Assert.AreEqual(disease.Deviations.Count, 0);
    }

    [Test]
    public void WhenDiseaseCreatedWithParanoiaType_ThenDiseaseTypeIsParanoia()
    {
        Disease disease = Disease.GetDisease(DiseaseType.PARANOIA);
        Assert.AreEqual(disease.Type, DiseaseType.PARANOIA);
    }
    [Test]
    public void WhenDiseaseCreatedWithParanoiaType_ThenDeviationsIsEqualToASpecificList()
    {
        Disease disease = Disease.GetDisease(DiseaseType.PARANOIA);
        Assert.AreEqual(disease.Deviations, new List<Deviation> { Deviation.ANXIETY, Deviation.SUSPICIOUS, Deviation.PANIC_ATTACKS, Deviation.INSOMNIA });
    }

    [Test]
    public void WhenDiseaseCreatedWithPsychosisType_ThenDiseaseTypeIsPsychosis()
    {
        Disease disease = Disease.GetDisease(DiseaseType.PSYCHOSIS);
        Assert.AreEqual(disease.Type, DiseaseType.PSYCHOSIS);
    }
    [Test]
    public void WhenDiseaseCreatedWithPsychosisType_ThenDeviationsIsEqualToASpecificList()
    {
        Disease disease = Disease.GetDisease(DiseaseType.PSYCHOSIS);
        Assert.AreEqual(disease.Deviations, new List<Deviation> { Deviation.HYSTERICS, Deviation.SELF_HARM, Deviation.IRRITABILITY, Deviation.INSOMNIA });
    }

    [Test]
    public void WhenDiseaseCreatedWithRaveType_ThenDiseaseTypeIsRave()
    {
        Disease disease = Disease.GetDisease(DiseaseType.RAVE);
        Assert.AreEqual(disease.Type, DiseaseType.RAVE);
    }
    [Test]
    public void WhenDiseaseCreatedWithRaveType_ThenDeviationsIsEmpty()
    {
        Disease disease = Disease.GetDisease(DiseaseType.RAVE);
        Assert.AreEqual(disease.Deviations.Count, 0);
    }

    [Test]
    public void WhenDiseaseCreatedWithSelfTortureType_ThenDiseaseTypeIsSelfTorture()
    {
        Disease disease = Disease.GetDisease(DiseaseType.SELF_TORTURE);
        Assert.AreEqual(disease.Type, DiseaseType.SELF_TORTURE);
    }
    [Test]
    public void WhenDiseaseCreatedWithSelfTortureType_ThenDeviationsIsEqualToASpecificList()
    {
        Disease disease = Disease.GetDisease(DiseaseType.SELF_TORTURE);
        Assert.AreEqual(disease.Deviations, new List<Deviation> { Deviation.MASOCHISM, Deviation.SELF_HARM, Deviation.SELF_FLAGELLATION });
    }

    [Test]
    public void WhenDiseaseCreatedWithSociopathyType_ThenDiseaseTypeIsSociopathy()
    {
        Disease disease = Disease.GetDisease(DiseaseType.SOCIOPATHY);
        Assert.AreEqual(disease.Type, DiseaseType.SOCIOPATHY);
    }
    [Test]
    public void WhenDiseaseCreatedWithSociopathyType_ThenDeviationsIsEqualToASpecificList()
    {
        Disease disease = Disease.GetDisease(DiseaseType.SOCIOPATHY);
        Assert.AreEqual(disease.Deviations, new List<Deviation> { Deviation.LACK_OF_EMOTION, Deviation.SELFISHNESS, Deviation.MANIPULATION });
    }

    [Test]
    public void WhenDiseaseCreatedWithVanityType_ThenDiseaseTypeIsVanity()
    {
        Disease disease = Disease.GetDisease(DiseaseType.VANITY);
        Assert.AreEqual(disease.Type, DiseaseType.VANITY);
    }
    [Test]
    public void WhenDiseaseCreatedWithVanityType_ThenDeviationsIsEqualToASpecificList()
    {
        Disease disease = Disease.GetDisease(DiseaseType.VANITY);
        Assert.AreEqual(disease.Deviations, new List<Deviation> { Deviation.PRIDE, Deviation.SELFISHNESS, Deviation.MEGALOMANIA });
    }

    [Test]
    public void WhenDiseaseCreatedWithMaxType_ThenDiseaseTypeIsMax()
    {
        Disease disease = Disease.GetDisease(DiseaseType.MAX);
        Assert.AreEqual(disease.Type, DiseaseType.MAX);
    }
    [Test]
    public void WhenDiseaseCreatedWithMaxType_ThenDeviationsIsNull()
    {
        Disease disease = Disease.GetDisease(DiseaseType.MAX);
        Assert.IsNull(disease.Deviations);
    }

    //Skill tests
    [Test]
    public void WhenSkillCreatedWithDiplomacyTypeAndLowestLevel_ThenSkillTypeIsDiplomacy()
    {
        Skill skill = Skill.GetSkill(SkillType.DIPLOMACY, SkillLevel.LOWEST);
        Assert.AreEqual(skill.Type, SkillType.DIPLOMACY);
    }
    [Test]
    public void WhenSkillCreatedWithDiplomacyTypeAndLowestLevel_ThenSkillLevelIsLowest()
    {
        Skill skill = Skill.GetSkill(SkillType.DIPLOMACY, SkillLevel.LOWEST);
        Assert.AreEqual(skill.Level, SkillLevel.LOWEST);
    }
    [Test]
    public void WhenSkillCreatedWithDiplomacyTypeAndLowestLevel_ThenDiseaseIsEqualToASpecificList()
    {
        Skill skill = Skill.GetSkill(SkillType.DIPLOMACY, SkillLevel.LOWEST);
        Assert.AreEqual(skill.Diseases, new List<DiseaseType> { DiseaseType.SOCIOPATHY, DiseaseType.DEPRESSION, DiseaseType.VANITY });
    }

    [Test]
    public void WhenSkillCreatedWithDiplomacyTypeAndLowLevel_ThenSkillTypeIsDiplomacy()
    {
        Skill skill = Skill.GetSkill(SkillType.DIPLOMACY, SkillLevel.LOW);
        Assert.AreEqual(skill.Type, SkillType.DIPLOMACY);
    }
    [Test]
    public void WhenSkillCreatedWithDiplomacyTypeAndLowLevel_ThenSkillLevelIsLow()
    {
        Skill skill = Skill.GetSkill(SkillType.DIPLOMACY, SkillLevel.LOW);
        Assert.AreEqual(skill.Level, SkillLevel.LOW);
    }
    [Test]
    public void WhenSkillCreatedWithDiplomacyTypeAndLowLevel_ThenDiseaseIsEqualToASpecificList()
    {
        Skill skill = Skill.GetSkill(SkillType.DIPLOMACY, SkillLevel.LOW);
        Assert.AreEqual(skill.Diseases, new List<DiseaseType> { DiseaseType.DEPRESSION });
    }

    [Test]
    public void WhenSkillCreatedWithDiplomacyTypeAndMiddleLevel_ThenSkillTypeIsDiplomacy()
    {
        Skill skill = Skill.GetSkill(SkillType.DIPLOMACY, SkillLevel.MIDDLE);
        Assert.AreEqual(skill.Type, SkillType.DIPLOMACY);
    }
    [Test]
    public void WhenSkillCreatedWithDiplomacyTypeAndMiddleLevel_ThenSkillLevelIsMiddle()
    {
        Skill skill = Skill.GetSkill(SkillType.DIPLOMACY, SkillLevel.MIDDLE);
        Assert.AreEqual(skill.Level, SkillLevel.MIDDLE);
    }
    [Test]
    public void WhenSkillCreatedWithDiplomacyTypeAndMiddleLevel_ThenDiseaseIsEqualToASpecificList()
    {
        Skill skill = Skill.GetSkill(SkillType.DIPLOMACY, SkillLevel.MIDDLE);
        Assert.AreEqual(skill.Diseases, new List<DiseaseType> { DiseaseType.GREED, DiseaseType.VANITY, DiseaseType.HALLUCINATIONS, DiseaseType.DEPRESSION });
    }

    [Test]
    public void WhenSkillCreatedWithDiplomacyTypeAndHighLevel_ThenSkillTypeIsDiplomacy()
    {
        Skill skill = Skill.GetSkill(SkillType.DIPLOMACY, SkillLevel.HIGH);
        Assert.AreEqual(skill.Type, SkillType.DIPLOMACY);
    }
    [Test]
    public void WhenSkillCreatedWithDiplomacyTypeAndHighLevel_ThenSkillLevelIsHigh()
    {
        Skill skill = Skill.GetSkill(SkillType.DIPLOMACY, SkillLevel.HIGH);
        Assert.AreEqual(skill.Level, SkillLevel.HIGH);
    }
    [Test]
    public void WhenSkillCreatedWithDiplomacyTypeAndHighLevel_ThenDiseaseIsEqualToASpecificList()
    {
        Skill skill = Skill.GetSkill(SkillType.DIPLOMACY, SkillLevel.HIGH);
        Assert.AreEqual(skill.Diseases, new List<DiseaseType> { DiseaseType.PSYCHOSIS, DiseaseType.RAVE, DiseaseType.GREED, DiseaseType.VANITY, DiseaseType.HALLUCINATIONS, DiseaseType.DEPRESSION });
    }

    [Test]
    public void WhenSkillCreatedWithWillTypeAndLowestLevel_ThenSkillTypeIsWill()
    {
        Skill skill = Skill.GetSkill(SkillType.WILL, SkillLevel.LOWEST);
        Assert.AreEqual(skill.Type, SkillType.WILL);
    }
    [Test]
    public void WhenSkillCreatedWithWillTypeAndLowestLevel_ThenSkillLevelIsLowest()
    {
        Skill skill = Skill.GetSkill(SkillType.WILL, SkillLevel.LOWEST);
        Assert.AreEqual(skill.Level, SkillLevel.LOWEST);
    }
    [Test]
    public void WhenSkillCreatedWithWillTypeAndLowestLevel_ThenDiseaseIsEqualToASpecificList()
    {
        Skill skill = Skill.GetSkill(SkillType.WILL, SkillLevel.LOWEST);
        Assert.AreEqual(skill.Diseases, new List<DiseaseType> { DiseaseType.ANGER, DiseaseType.SOCIOPATHY, DiseaseType.PSYCHOSIS, DiseaseType.VANITY });
    }

    [Test]
    public void WhenSkillCreatedWithWillTypeAndLowLevel_ThenSkillTypeIsWill()
    {
        Skill skill = Skill.GetSkill(SkillType.WILL, SkillLevel.LOW);
        Assert.AreEqual(skill.Type, SkillType.WILL);
    }
    [Test]
    public void WhenSkillCreatedWithWillTypeAndLowLevel_ThenSkillLevelIsLow()
    {
        Skill skill = Skill.GetSkill(SkillType.WILL, SkillLevel.LOW);
        Assert.AreEqual(skill.Level, SkillLevel.LOW);
    }
    [Test]
    public void WhenSkillCreatedWithWillTypeAndLowLevel_ThenDiseaseIsEqualToASpecificList()
    {
        Skill skill = Skill.GetSkill(SkillType.WILL, SkillLevel.LOW);
        Assert.AreEqual(skill.Diseases, new List<DiseaseType> { DiseaseType.VANITY, DiseaseType.GREED });
    }

    [Test]
    public void WhenSkillCreatedWithWillTypeAndMiddleLevel_ThenSkillTypeIsWill()
    {
        Skill skill = Skill.GetSkill(SkillType.WILL, SkillLevel.MIDDLE);
        Assert.AreEqual(skill.Type, SkillType.WILL);
    }
    [Test]
    public void WhenSkillCreatedWithWillTypeAndMiddleLevel_ThenSkillLevelIsMiddle()
    {
        Skill skill = Skill.GetSkill(SkillType.WILL, SkillLevel.MIDDLE);
        Assert.AreEqual(skill.Level, SkillLevel.MIDDLE);
    }
    [Test]
    public void WhenSkillCreatedWithWillTypeAndMiddleLevel_ThenDiseaseIsEqualToASpecificList()
    {
        Skill skill = Skill.GetSkill(SkillType.WILL, SkillLevel.MIDDLE);
        Assert.AreEqual(skill.Diseases, new List<DiseaseType> { DiseaseType.ANGER, DiseaseType.RAVE, DiseaseType.VANITY, DiseaseType.GREED });
    }

    [Test]
    public void WhenSkillCreatedWithWillTypeAndHighLevel_ThenSkillTypeIsWill()
    {
        Skill skill = Skill.GetSkill(SkillType.WILL, SkillLevel.HIGH);
        Assert.AreEqual(skill.Type, SkillType.WILL);
    }
    [Test]
    public void WhenSkillCreatedWithWillTypeAndHighLevel_ThenSkillLevelIsHigh()
    {
        Skill skill = Skill.GetSkill(SkillType.WILL, SkillLevel.HIGH);
        Assert.AreEqual(skill.Level, SkillLevel.HIGH);
    }
    [Test]
    public void WhenSkillCreatedWithWillTypeAndHighLevel_ThenDiseaseIsEqualToASpecificList()
    {
        Skill skill = Skill.GetSkill(SkillType.WILL, SkillLevel.HIGH);
        Assert.AreEqual(skill.Diseases, new List<DiseaseType> { DiseaseType.PSYCHOSIS, DiseaseType.SOCIOPATHY, DiseaseType.ANGER, DiseaseType.RAVE, DiseaseType.VANITY, DiseaseType.GREED });
    }

    [Test]
    public void WhenSkillCreatedWithPhysicalTypeAndLowestLevel_ThenSkillTypeIsPhysical()
    {
        Skill skill = Skill.GetSkill(SkillType.PHYSICAL, SkillLevel.LOWEST);
        Assert.AreEqual(skill.Type, SkillType.PHYSICAL);
    }
    [Test]
    public void WhenSkillCreatedWithPhysicalTypeAndLowestLevel_ThenSkillLevelIsLowest()
    {
        Skill skill = Skill.GetSkill(SkillType.PHYSICAL, SkillLevel.LOWEST);
        Assert.AreEqual(skill.Level, SkillLevel.LOWEST);
    }
    [Test]
    public void WhenSkillCreatedWithPhysicalTypeAndLowestLevel_ThenDiseaseIsEqualToASpecificList()
    {
        Skill skill = Skill.GetSkill(SkillType.PHYSICAL, SkillLevel.LOWEST);
        Assert.AreEqual(skill.Diseases, new List<DiseaseType> { DiseaseType.ANGER, DiseaseType.PSYCHOSIS, DiseaseType.SELF_TORTURE });
    }

    [Test]
    public void WhenSkillCreatedWithPhysicalTypeAndLowLevel_ThenSkillTypeIsPhysical()
    {
        Skill skill = Skill.GetSkill(SkillType.PHYSICAL, SkillLevel.LOW);
        Assert.AreEqual(skill.Type, SkillType.PHYSICAL);
    }
    [Test]
    public void WhenSkillCreatedWithPhysicalTypeAndLowLevel_ThenSkillLevelIsLow()
    {
        Skill skill = Skill.GetSkill(SkillType.PHYSICAL, SkillLevel.LOW);
        Assert.AreEqual(skill.Level, SkillLevel.LOW);
    }
    [Test]
    public void WhenSkillCreatedWithPhysicalTypeAndLowLevel_ThenDiseaseIsEqualToASpecificList()
    {
        Skill skill = Skill.GetSkill(SkillType.PHYSICAL, SkillLevel.LOW);
        Assert.AreEqual(skill.Diseases, new List<DiseaseType> { DiseaseType.SELF_TORTURE });
    }

    [Test]
    public void WhenSkillCreatedWithPhysicalTypeAndMiddleLevel_ThenSkillTypeIsPhysical()
    {
        Skill skill = Skill.GetSkill(SkillType.PHYSICAL, SkillLevel.MIDDLE);
        Assert.AreEqual(skill.Type, SkillType.PHYSICAL);
    }
    [Test]
    public void WhenSkillCreatedWithPhysicalTypeAndMiddleLevel_ThenSkillLevelIsMiddle()
    {
        Skill skill = Skill.GetSkill(SkillType.PHYSICAL, SkillLevel.MIDDLE);
        Assert.AreEqual(skill.Level, SkillLevel.MIDDLE);
    }
    [Test]
    public void WhenSkillCreatedWithPhysicalTypeAndMiddleLevel_ThenDiseaseIsEqualToASpecificList()
    {
        Skill skill = Skill.GetSkill(SkillType.PHYSICAL, SkillLevel.MIDDLE);
        Assert.AreEqual(skill.Diseases, new List<DiseaseType> { DiseaseType.PSYCHOSIS, DiseaseType.SELF_TORTURE });
    }

    [Test]
    public void WhenSkillCreatedWithPhysicalTypeAndHighLevel_ThenSkillTypeIsPhysical()
    {
        Skill skill = Skill.GetSkill(SkillType.PHYSICAL, SkillLevel.HIGH);
        Assert.AreEqual(skill.Type, SkillType.PHYSICAL);
    }
    [Test]
    public void WhenSkillCreatedWithPhysicalTypeAndHighLevel_ThenSkillLevelIsHigh()
    {
        Skill skill = Skill.GetSkill(SkillType.PHYSICAL, SkillLevel.HIGH);
        Assert.AreEqual(skill.Level, SkillLevel.HIGH);
    }
    [Test]
    public void WhenSkillCreatedWithPhysicalTypeAndHighLevel_ThenDiseaseIsEqualToASpecificList()
    {
        Skill skill = Skill.GetSkill(SkillType.PHYSICAL, SkillLevel.HIGH);
        Assert.AreEqual(skill.Diseases, new List<DiseaseType> { DiseaseType.ANGER, DiseaseType.PSYCHOSIS, DiseaseType.SELF_TORTURE });
    }

    [Test]
    public void WhenSkillCreatedWithEmpathyTypeAndLowestLevel_ThenSkillTypeIsEmpathy()
    {
        Skill skill = Skill.GetSkill(SkillType.EMPATHY, SkillLevel.LOWEST);
        Assert.AreEqual(skill.Type, SkillType.EMPATHY);
    }
    [Test]
    public void WhenSkillCreatedWithEmpathyTypeAndLowestLevel_ThenSkillLevelIsLowest()
    {
        Skill skill = Skill.GetSkill(SkillType.EMPATHY, SkillLevel.LOWEST);
        Assert.AreEqual(skill.Level, SkillLevel.LOWEST);
    }
    [Test]
    public void WhenSkillCreatedWithEmpathyTypeAndLowestLevel_ThenDiseaseIsEqualToASpecificList()
    {
        Skill skill = Skill.GetSkill(SkillType.EMPATHY, SkillLevel.LOWEST);
        Assert.AreEqual(skill.Diseases, new List<DiseaseType> { DiseaseType.PARANOIA, DiseaseType.DEPRESSION, DiseaseType.PSYCHOSIS });
    }

    [Test]
    public void WhenSkillCreatedWithEmpathyTypeAndLowLevel_ThenSkillTypeIsEmpathy()
    {
        Skill skill = Skill.GetSkill(SkillType.EMPATHY, SkillLevel.LOW);
        Assert.AreEqual(skill.Type, SkillType.EMPATHY);
    }
    [Test]
    public void WhenSkillCreatedWithEmpathyTypeAndLowLevel_ThenSkillLevelIsLow()
    {
        Skill skill = Skill.GetSkill(SkillType.EMPATHY, SkillLevel.LOW);
        Assert.AreEqual(skill.Level, SkillLevel.LOW);
    }
    [Test]
    public void WhenSkillCreatedWithEmpathyTypeAndLowLevel_ThenDiseaseIsEqualToASpecificList()
    {
        Skill skill = Skill.GetSkill(SkillType.EMPATHY, SkillLevel.LOW);
        Assert.AreEqual(skill.Diseases, new List<DiseaseType> { DiseaseType.DEPRESSION });
    }

    [Test]
    public void WhenSkillCreatedWithEmpathyTypeAndMiddleLevel_ThenSkillTypeIsEmpathy()
    {
        Skill skill = Skill.GetSkill(SkillType.EMPATHY, SkillLevel.MIDDLE);
        Assert.AreEqual(skill.Type, SkillType.EMPATHY);
    }
    [Test]
    public void WhenSkillCreatedWithEmpathyTypeAndMiddleLevel_ThenSkillLevelIsMiddle()
    {
        Skill skill = Skill.GetSkill(SkillType.EMPATHY, SkillLevel.MIDDLE);
        Assert.AreEqual(skill.Level, SkillLevel.MIDDLE);
    }
    [Test]
    public void WhenSkillCreatedWithEmpathyTypeAndMiddleLevel_ThenDiseaseIsEqualToASpecificList()
    {
        Skill skill = Skill.GetSkill(SkillType.EMPATHY, SkillLevel.MIDDLE);
        Assert.AreEqual(skill.Diseases, new List<DiseaseType> { DiseaseType.PARANOIA, DiseaseType.HALLUCINATIONS, DiseaseType.DEPRESSION });
    }

    [Test]
    public void WhenSkillCreatedWithEmpathyTypeAndHighLevel_ThenSkillTypeIsEmpathy()
    {
        Skill skill = Skill.GetSkill(SkillType.EMPATHY, SkillLevel.HIGH);
        Assert.AreEqual(skill.Type, SkillType.EMPATHY);
    }
    [Test]
    public void WhenSkillCreatedWithEmpathyTypeAndHighLevel_ThenSkillLevelIsHigh()
    {
        Skill skill = Skill.GetSkill(SkillType.EMPATHY, SkillLevel.HIGH);
        Assert.AreEqual(skill.Level, SkillLevel.HIGH);
    }
    [Test]
    public void WhenSkillCreatedWithEmpathyTypeAndHighLevel_ThenDiseaseIsEqualToASpecificList()
    {
        Skill skill = Skill.GetSkill(SkillType.EMPATHY, SkillLevel.HIGH);
        Assert.AreEqual(skill.Diseases, new List<DiseaseType> { DiseaseType.PSYCHOSIS, DiseaseType.PARANOIA, DiseaseType.HALLUCINATIONS, DiseaseType.DEPRESSION });
    }

    [Test]
    public void WhenSkillCreatedWithAdditionalTypeAndLowestLevel_ThenSkillTypeIsAdditional()
    {
        Skill skill = Skill.GetSkill(SkillType.ADDITIONAL, SkillLevel.LOWEST);
        Assert.AreEqual(skill.Type, SkillType.ADDITIONAL);
    }
    [Test]
    public void WhenSkillCreatedWithAdditionalTypeAndLowestLevel_ThenSkillLevelIsLowest()
    {
        Skill skill = Skill.GetSkill(SkillType.ADDITIONAL, SkillLevel.LOWEST);
        Assert.AreEqual(skill.Level, SkillLevel.LOWEST);
    }
    [Test]
    public void WhenSkillCreatedWithAdditionalTypeAndLowestLevel_ThenDiseaseIsEqualToASpecificList()
    {
        Skill skill = Skill.GetSkill(SkillType.ADDITIONAL, SkillLevel.LOWEST);
        Assert.AreEqual(skill.Diseases, new List<DiseaseType> { DiseaseType.ANGER, DiseaseType.SELF_TORTURE });
    }

    [Test]
    public void WhenSkillCreatedWithAdditionalTypeAndLowLevel_ThenSkillTypeIsAdditional()
    {
        Skill skill = Skill.GetSkill(SkillType.ADDITIONAL, SkillLevel.LOW);
        Assert.AreEqual(skill.Type, SkillType.ADDITIONAL);
    }
    [Test]
    public void WhenSkillCreatedWithAdditionalTypeAndLowLevel_ThenSkillLevelIsLow()
    {
        Skill skill = Skill.GetSkill(SkillType.ADDITIONAL, SkillLevel.LOW);
        Assert.AreEqual(skill.Level, SkillLevel.LOW);
    }
    [Test]
    public void WhenSkillCreatedWithAdditionalTypeAndLowLevel_ThenDiseaseIsEqualToASpecificList()
    {
        Skill skill = Skill.GetSkill(SkillType.ADDITIONAL, SkillLevel.LOW);
        Assert.AreEqual(skill.Diseases, new List<DiseaseType> { DiseaseType.ANGER, DiseaseType.SELF_TORTURE });
    }

    [Test]
    public void WhenSkillCreatedWithAdditionalTypeAndMiddleLevel_ThenSkillTypeIsAdditional()
    {
        Skill skill = Skill.GetSkill(SkillType.ADDITIONAL, SkillLevel.MIDDLE);
        Assert.AreEqual(skill.Type, SkillType.ADDITIONAL);
    }
    [Test]
    public void WhenSkillCreatedWithAdditionalTypeAndMiddleLevel_ThenSkillLevelIsMiddle()
    {
        Skill skill = Skill.GetSkill(SkillType.ADDITIONAL, SkillLevel.MIDDLE);
        Assert.AreEqual(skill.Level, SkillLevel.MIDDLE);
    }
    [Test]
    public void WhenSkillCreatedWithAdditionalTypeAndMiddleLevel_ThenDiseaseIsEqualToASpecificList()
    {
        Skill skill = Skill.GetSkill(SkillType.ADDITIONAL, SkillLevel.MIDDLE);
        Assert.AreEqual(skill.Diseases, new List<DiseaseType> { DiseaseType.ANGER, DiseaseType.SELF_TORTURE });
    }

    [Test]
    public void WhenSkillCreatedWithAdditionalTypeAndHighLevel_ThenSkillTypeIsAdditional()
    {
        Skill skill = Skill.GetSkill(SkillType.ADDITIONAL, SkillLevel.HIGH);
        Assert.AreEqual(skill.Type, SkillType.ADDITIONAL);
    }
    [Test]
    public void WhenSkillCreatedWithAdditionalTypeAndHighLevel_ThenSkillLevelIsHigh()
    {
        Skill skill = Skill.GetSkill(SkillType.ADDITIONAL, SkillLevel.HIGH);
        Assert.AreEqual(skill.Level, SkillLevel.HIGH);
    }
    [Test]
    public void WhenSkillCreatedWithAdditionalTypeAndHighLevel_ThenDiseaseIsEqualToASpecificList()
    {
        Skill skill = Skill.GetSkill(SkillType.ADDITIONAL, SkillLevel.HIGH);
        Assert.AreEqual(skill.Diseases, new List<DiseaseType> { DiseaseType.ANGER, DiseaseType.SELF_TORTURE });
    }

}
