using System.Runtime.Serialization;

[DataContract]
[System.Serializable]
public class PatientData
{
    [DataMember]
    public int hairId;
    [DataMember]
    public int skinId;

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
        hairId = patient.hair != null ? patient.hair.GetComponent<Hair>().Id : 0;
        skinId = patient.skin != null ? patient.skin.GetComponent<Skin>().Id : 0;

        sex = patient.Sex;
        name = patient.Name;
        surname = patient.Surname;
        patronymic = patient.Patronymic;
        age = patient.Age;
        maxToxic = patient.MaxToxic;
        toxic = patient.Toxic;
        speed = patient.Speed;
        diseases = new DiseaseType[patient.Diseases.Count];
        for (int i = 0; i < patient.Diseases.Count; i++)
        {
            diseases[i] = patient.Diseases[i];
        }
    }

}
