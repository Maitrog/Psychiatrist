using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        Save();
    }

    private void Save()
    {
        PlayerData data = new PlayerData();
        string filename = Application.persistentDataPath + "/PlayerData.bin";
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, data);
        stream.Close();
    }
}
