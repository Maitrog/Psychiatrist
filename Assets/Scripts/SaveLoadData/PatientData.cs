using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[DataContract]
public class PatientData
{
    [DataMember]
    public HairData hair;
    [DataMember]
    public FaceData face;

    [DataMember]
    public Sex sex;
    [DataMember]
    public string name;
    [DataMember]
    public string surname;
    [DataMember]
    public string patronymic;
    [DataMember]
    public int age;
    [DataMember]
    public double maxToxic;
    [DataMember]
    public double toxic = 0;
    [DataMember]
    public double speed;
    [DataMember]
    public DiseaseType[] diseases;

    public PatientData(PatientObject patient)
    {
        hair = new HairData(patient.hair);
        face = new FaceData(patient.face);

        sex = patient.Sex;
        name = patient.name;
        surname = patient.Surname;
        patronymic = patient.Patronymic;
        age = patient.Age;
        maxToxic = patient.MaxToxic;
        toxic = patient.Toxic;
        speed = patient.Speed;
        diseases = new DiseaseType[patient.Diseases.Count];
        for(int i = 0; i < patient.Diseases.Count; i++)
        {
            diseases[i] = patient.Diseases[i];
        }
    }

}
