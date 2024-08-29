using System;
using Unity.VisualScripting;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    public float velocity = 4.5f;
    [Header("Clues")]
    private bool clueFind1 = false;
    private bool clueFind2 = false;
    private bool openDoor = false;
    [Space]
    
    [Header("Health")]
    [SerializeField] private int Health = 100;
    [SerializeField] private int decreaseHealth = 5;
    [SerializeField] private int increaseHealth = 10;
    [Space]
    
    [Header("Danger")]
    [SerializeField] private GameObject dangerZoneUI;
    [SerializeField] private GameObject healthZoneUI;
    
    [Space]
    
    [Header("Door")]
    private Animator doorAnimator; //referencia animator de unity del componente
    [SerializeField] private GameObject door;
    private Collider doorCollider;
    [SerializeField] private GameObject doorColliderGameObject;

    [Space]

    [Header("Lights")]
    [SerializeField] private Light _light ;
    [SerializeField] private bool Afternoon;
    private Animator downSun;
    private Collider safeCollider;
    [SerializeField] private GameObject healthzoneColliderGameObject;
    
    private void Start()
    {
        Application.targetFrameRate = 60;
        doorAnimator = door.GetComponent<Animator>();
        downSun = _light.GetComponent<Animator>();

    }
    private void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        { //pistas para abrir la puerta
            case "Clue1":
                clueFind1 = true;
                Debug.Log("Recogiste la linterna");
                break;
            case "Clue2":
                clueFind2 = true;
                Debug.Log("Encontraste las pilas de la linterna, ¿pensaste que es infinita?");
                break;
            case "Door":
                if (clueFind1 || clueFind2)
                {
                    openDoor = true;
                    doorAnimator.SetBool("AnimDoor", true);
                    
                    Debug.Log("Tienes las dos pistas, felicidades, aborto planeado");
                    
                }
                else
                {
                    Debug.Log("¿Para que tienes este juego si nisiquiera vas a jugarlo, niño adoptado?");
                }
                break;
            //activar ui
            case "Damage":
                if (openDoor == true)
                {
                    Health -= decreaseHealth;
                    dangerZoneUI.SetActive(true);
                }
                break;
            case "Health":
                if (openDoor == true)
                {
                    Health += increaseHealth;
                    healthZoneUI.SetActive(true);
                    downSun.SetBool("AnimSun",true);
                }
                break;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Door":
                doorAnimator.SetBool("AnimDoor",false);
                doorCollider = doorColliderGameObject.GetComponent<Collider>();
                doorCollider.enabled = false; 
                break;
            case "Light":
            {
                doorAnimator.SetBool("AnimSun",false);
                safeCollider = healthzoneColliderGameObject.GetComponent<Collider>();
                break;
            }
            case "Health":
            {
                healthZoneUI.SetActive(false);
                downSun.SetBool("AnimSun",false);
                break;
            }
            //desactivar ui
            case "Damage":
            {
                dangerZoneUI.SetActive(false);
                break;
            }
            
        }
        
    }



}
