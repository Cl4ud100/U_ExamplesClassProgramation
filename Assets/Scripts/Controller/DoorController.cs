using System;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private ClueController clueController; //conecta el scritp como varaible
    [SerializeField] private GameObject doorAnimatorGO;
    [SerializeField] private GameObject doorColliderGO;
    private Collider doorCollider;
    private Animator doorAnimator;
    /* If AllCluesCollected
     {
        isOpenDoor = true
        }
        
    }*/
    private void Start()
    {
        doorCollider = doorColliderGO.GetComponent<Collider>();
        doorAnimator = doorAnimatorGO.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (clueController.AllCluesCollected()) //busca dentro de la varaible el metodo del script nombrado
        {
            doorAnimator.SetBool("AnimDoor",true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        doorAnimator.SetBool("AnimDoor", false);
        doorCollider.enabled = false;
    }
}
