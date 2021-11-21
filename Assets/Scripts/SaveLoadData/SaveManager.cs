using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        Save();
    }

    private void Save()
    {
        Debug.Log(Application.persistentDataPath);

        // Stream the file with a File Stream. (Note that File.Create() 'Creates' or 'Overwrites' a file.)
        FileStream file = File.Create(Application.persistentDataPath + "/PlayerData.dat");
       
        // Create a new Player_Data.
        PlayerData data = new PlayerData();

        //Serialize to xml
        DataContractSerializer bf = new DataContractSerializer(data.GetType());
        MemoryStream streamer = new MemoryStream();

        //Serialize the file
        bf.WriteObject(streamer, data);
        streamer.Seek(0, SeekOrigin.Begin);

        //Save to disk
        file.Write(streamer.GetBuffer(), 0, streamer.GetBuffer().Length);

        // Close the file to prevent any corruptions
        file.Close();
    }
}
