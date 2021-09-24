using UnityEngine;

public enum ItemType
{
    Tablets,
    Devices,
    Default
}

public enum Attributes
{
    Price,
    Rarity
}
public abstract class ItemObject : ScriptableObject
{
    public int Id;
    public Sprite uiDisplay;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
    public ItemAttribute[] attributes;

    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}

[System.Serializable]
public class Item
{
    public string Name;
    public int Id;
    public ItemAttribute[] attributes;
    public Item(ItemObject item)
    {
        Name = item.name;
        Id = item.Id;
        attributes = new ItemAttribute[item.attributes.Length];
        for(int i = 0; i < attributes.Length; i++)
        {
            attributes[i] = new ItemAttribute(item.attributes[i].min, item.attributes[i].max);
            attributes[i].attribute = item.attributes[i].attribute;
        }
    }
}
[System.Serializable]
public class ItemAttribute
{
    public Attributes attribute;
    public int value;
    public int min;
    public int max;
    public ItemAttribute(int _min, int _max)
    {
        min = _min;
        max = _max;
        generateValue();
    }
    public void generateValue()
    {
        value = Random.Range(min, max);
    }
}