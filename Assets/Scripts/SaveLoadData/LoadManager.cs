using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    public FacesDatabaseObject facesDatabaseObject;
    public PhotoDatabeseObject photoDatabeseObject;
    private void Awake()
    {
        Load();
    }

    private void Load()
    {
        string filename = Application.persistentDataPath + "/PlayerData.bin";
        if (File.Exists(filename))
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            PlayerData data = (PlayerData)formatter.Deserialize(stream);
            stream.Close();
            StaticCurrentPatients.BecomeCurrent(data.currentPatientsData, facesDatabaseObject);
            StaticCurrentParamedics.BecomeCurrent(data.currentParamedicsData, photoDatabeseObject);
        }
    }
}
