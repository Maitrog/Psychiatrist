using System.Runtime.Serialization;

[DataContract]
[System.Serializable]
public class PlayerData
{
    [DataMember]
    public CurrentParamedicsData currentParamedicsData;
    [DataMember]
    public CurrentPatientsData currentPatientsData;

    public PlayerData()
    {
        currentPatientsData = new CurrentPatientsData();
        currentParamedicsData = new CurrentParamedicsData();
    }
}
