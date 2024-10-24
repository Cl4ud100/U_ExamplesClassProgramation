using UnityEngine;

[System.Serializable]
public class Item
{
    public string _itemName;
    public string _itemDescription;

    public Item(string itemName, string itemDescription)
    {
        _itemName = itemName;
        _itemDescription = itemDescription;
    }


}

