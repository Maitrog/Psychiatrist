using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Photo Database", menuName = "Photo/Database")]
public class PhotoDatabeseObject : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField]
    private Photo[] photos;
    public Dictionary<int, Photo> GetPhoto = new Dictionary<int, Photo>();
    public void OnAfterDeserialize()
    {
        for (int i = 0; i < photos.Length; i++)
        {
            photos[i].Id = i;
            GetPhoto.Add(i, photos[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        GetPhoto = new Dictionary<int, Photo>();
    }
}
