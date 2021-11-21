using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    private void Awake()
    {
        Load();
    }

    private void Load()
    {
        // Stream the file with a File Stream. (Note that File.Create() 'Creates' or 'Overwrites' a file.)
        FileStream fs = File.Create(Application.persistentDataPath + "/PlayerData.dat");
        XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());

        // Create a new Player_Data.
        PlayerData data = new PlayerData();

        //MemoryStream streamer = new MemoryStream();
        //file.Read(streamer.GetBuffer(), 0, (int)file.Length);
        //file.Close();

        DataContractSerializer bf = new DataContractSerializer(data.GetType());
        data = bf.ReadObject(reader, true) as PlayerData;
        reader.Close();

        StaticCurrentPatients.BecomeCurrent(data.currentPatientsData);
        StaticCurrentParamedics.BecomeCurrent(data.currentParamedicsData);
    }
}
