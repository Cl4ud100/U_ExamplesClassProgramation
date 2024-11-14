using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
   //lista que almacena los items del inventario.
   public List<Item> itemList = new List<Item>();
   
   //Referencia al panel del inventario de la UI
   public GameObject InventoryPanel;
   //Referencia al Prefab
   public GameObject inventoryItemPrefab;

   private bool inventoryVisible = true;
    
   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.I))
      {
         inventoryVisible = !inventoryVisible;
         InventoryPanel.SetActive(inventoryVisible);
      }
   }

   //Método o funcion para agregar un item al inventario
   public void AddItem(Item item) //(clase, item)
   {
      itemList.Add(item);
      Debug.Log("Item Added" + item._itemName);
      UpdateInventoryUI();
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

   public void UpdateInventoryUI()
   {
      //Limpiar los items actuales del inventario
      foreach (Transform child in InventoryPanel.transform)
      {
         Destroy(child.gameObject);
      }
      
      //crear un elemento UI por cada item recolectado
      foreach (Item item in itemList)
      {
         //instanciar el prefab
         //Crear variable de tipo gameObject y que obtenga la instancia
         GameObject itemUI = Instantiate(inventoryItemPrefab, InventoryPanel.transform);
         //Configurar el texto del nombre
         TextMeshProUGUI nameText = itemUI.transform.Find("ItemNameText").GetComponent<TextMeshProUGUI>();
         nameText.text = item._itemName;
         
         //configurar la imagen del item
         Image iconImage = itemUI.GetComponent<Image>();
         iconImage.sprite = item._itemImage;
         

      }
   }
}
