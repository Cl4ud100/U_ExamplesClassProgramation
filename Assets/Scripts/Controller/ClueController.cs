using System;
using UnityEngine;

public class ClueController : MonoBehaviour
{
    private bool Clue1Found;
    private bool Clue2Found;
    
    private Inventory playerInventory;

    [SerializeField] private Sprite clue1Icon;
    [SerializeField] private Sprite clue2Icon;


    private void Start()
    {
        playerInventory = GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Clue1":
                Clue1Found = true;
                Debug.Log("Clue1 Found");
                //crear un nuevo item para la pista 1
                Item clue1Item = new Item("Clue1","Primera pista",clue1Icon);
                //agregar al inventario
                playerInventory.AddItem(clue1Item);
                //destruir el objeto coleccionado
                //esto es para destruir al padre y al hijo
                Destroy(other.transform.parent.gameObject);
                break;
            case "Clue2":
                Clue2Found = true;
                Debug.Log("Clue2 Found");
                Item clue2Item = new Item("Clue2","Segunda pista",clue2Icon);
                playerInventory.AddItem(clue2Item);
                Destroy(other.transform.parent.gameObject);
                break;
            
        }
    }

    public bool AllCluesCollected()
    {
        //verificacion si el inventario tiene ambas partes
        bool hasClue1 = playerInventory.HasItem("Clue1");
        bool hasClue2 = playerInventory.HasItem("Clue2");
        return hasClue1 && hasClue2;
        //return Clue1Found && Clue2Found;
    }
}
