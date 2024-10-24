using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   //lista que almacena los items del inventario.
   public List<Item> itemList = new List<Item>();
   
   //Método o funcion para agregar un item al inventario
   public void AddItem(Item item) //(clase, item)
   {
      itemList.Add(item);
      Debug.Log("Item Added" + item._itemName);
   }
   
   public bool HasItem(string itemName)
   {
      foreach (Item item in itemList)
      {
         if (item._itemName == itemName)
         {
            return true;
         }
      }
      return false;
   }
}
