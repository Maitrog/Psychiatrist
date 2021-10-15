using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Current Paramedic", menuName = "CurrentParamedic")]
public class CurrentParamedicObject : ScriptableObject
{
    public List<ParamedicObject> currentParamedics;

    public void AddParamedic(ParamedicObject paramedic)
    {
        currentParamedics.Add(paramedic);
    }
    public void DeleteParamedic(int index)
    {
        AssetDatabase.DeleteAsset($"Assets/Scriptable Object/Paramedic/{index}.asset");
        currentParamedics.RemoveAt(index);
    }

    internal void DeleteAll()
    {
        int count = currentParamedics.Count;
        for (int i = 0; i < count; i++)
        {
            AssetDatabase.DeleteAsset($"Assets/Scriptable Object/Paramedic/{i}.asset");
            currentParamedics.RemoveAt(0);
        }
    }
}
