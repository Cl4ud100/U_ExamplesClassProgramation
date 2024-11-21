using System;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private ClueController clueController; //conecta el scritp como varaible
    [SerializeField] private GameObject doorAnimatorGO;
    [SerializeField] private GameObject doorColliderGO;
    private Collider doorCollider;
    private Animator doorAnimator;
    private Inventory Playerinventory;
    
    private void Start()
    {
        doorCollider = doorColliderGO.GetComponent<Collider>();
        doorAnimator = doorAnimatorGO.GetComponent<Animator>();
        //obtener inventario jugador
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Playerinventory = player.GetComponent<Inventory>();
        }
        else
        {
            Debug.Log("No player found. Verificar Tag player");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (clueController.AllCluesCollected()) //busca dentro de la varaible el metodo del script nombrado
        {
            doorAnimator.SetBool("AnimDoor",true);
            //eliminar pistas del inventario
            Playerinventory.RemoveItem("Clue1");
            Playerinventory.RemoveItem("Clue2");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        doorAnimator.SetBool("AnimDoor", false);
        doorCollider.enabled = false;
    }
}
