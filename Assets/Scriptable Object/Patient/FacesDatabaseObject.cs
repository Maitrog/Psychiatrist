using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Faces Database", menuName = "Faces/Database")]
public class FacesDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField]
    private Skin[] skins;
    [SerializeField]
    private Hair[] maleHairs;
    [SerializeField]
    private Hair[] femaleHairs;
    public Dictionary<int, Skin> GetSkin = new Dictionary<int, Skin>();
    public Dictionary<int, Hair> GetMaleHair = new Dictionary<int, Hair>();
    public Dictionary<int, Hair> GetFemaleHair = new Dictionary<int, Hair>();

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < skins.Length; i++)
        {
            skins[i].Id = i;
            GetSkin.Add(i, skins[i]);
        }
        for (int i = 0; i < maleHairs.Length; i++)
        {
            maleHairs[i].Id = i;
            GetMaleHair.Add(i, maleHairs[i]);
        }
        for (int i = 0; i < femaleHairs.Length; i++)
        {
            femaleHairs[i].Id = i;
            GetFemaleHair.Add(i, femaleHairs[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        GetSkin = new Dictionary<int, Skin>();
        GetMaleHair = new Dictionary<int, Hair>();
    }
}
