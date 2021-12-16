using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Methods")]
public class MethodsObject : ScriptableObject
{
    public ItemsDatabaseObject database;
    public LocalInventory container;
    public string saveMethodsPath;
    public void AddItem(Item _item, int _amount)
    {
        if (_item.attributes.Length > 0)
        {
            SetEmptySlot(_item, _amount);
            return;
        }

        for (int i = 0; i < container.items.Length; i++)
        {
            if (container.items[i].ID == _item.Id)
            {
                container.items[i].AddAmount(_amount);
                return;
            }
        }

        SetEmptySlot(_item, _amount);
    }

    public InventorySlot SetEmptySlot(Item _item, int _amount)
    {
        for (int i = 0; i < container.items.Length; i++)
        {
            if (container.items[i].ID <= -1)
            {
                container.items[i].UpdateSlot(_item.Id, _item, _amount);
                return container.items[i];
            }
        }
        //set up when full
        return null;
    }

    public void MoveItem(InventorySlot item1, InventorySlot item2)
    {
        InventorySlot tmp = new InventorySlot(item2.ID, item2.item, item2.amount);
        item2.UpdateSlot(item1.ID, item1.item, item1.amount);
        item1.UpdateSlot(tmp.ID, tmp.item, tmp.amount);
    }

    public void RemoveItem(Item _item)
    {
        for (int i = 0; i < container.items.Length; i++)
        {
            if (container.items[i].item == _item)
            {
                container.items[i].UpdateSlot(-1, null, 0);
            }
        }
    }

    [ContextMenu("Save")]
    public void Save()
    {
        try
        {
            //string saveData = JsonUtility.ToJson(this, true);
            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
            //bf.Serialize(file, saveData);
            //file.Close();

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, saveMethodsPath), FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, container);
            stream.Close();
        }
        catch
        {
            Debug.Log("SAVE ERROR");
        }
    }
    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, saveMethodsPath)))
        {
            try
            {
                //BinaryFormatter bf = new BinaryFormatter();
                //FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
                //JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
                //file.Close();

                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(string.Concat(Application.persistentDataPath, saveMethodsPath), FileMode.Open, FileAccess.Read);
                LocalInventory newContainer = (LocalInventory)formatter.Deserialize(stream);
                for (int i = 0; i < container.items.Length; i++)
                {
                    container.items[i].UpdateSlot(newContainer.items[i].ID, newContainer.items[i].item, newContainer.items[i].amount);
                }
                stream.Close();
            }
            catch
            {
                Debug.Log("LOAD ERROR");
            }
        }
    }
}
