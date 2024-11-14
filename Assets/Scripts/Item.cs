using UnityEngine;

[System.Serializable]
public class Item
{
    public string _itemName;
    public string _itemDescription;
    public Sprite _itemImage;

    public Item(string itemName, string itemDescription, Sprite itemIcon)
    {
        _itemName = itemName;
        _itemDescription = itemDescription;
        _itemImage = itemIcon;
    }


}

