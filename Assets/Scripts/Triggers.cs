using System;
using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Triggers : MonoBehaviour
{
    public float velocity = 4.5f;
    [Header("Clues")]
    private bool clueFind1;
    private bool clueFind2;
    private bool openDoor;
    [Space]
    
    [Header("Health and damage")]
    [Tooltip("la vida debe partir en 100")]
    [Space]
    [SerializeField] private int Health = 100;
    [SerializeField] private int decreaseHealth = 5;
    [SerializeField] private int increaseHealth = 10;
    [Space]
    
    [Header("Zones")]
    [SerializeField] private GameObject dangerZoneUI;
    [SerializeField] private GameObject healthZoneUI;
    
    [Space]
    
    [Header("Door")]
    [Tooltip("Arrastra el objeto animado")]
    private Animator doorAnimator; //referencia animator de unity del componente
    [SerializeField] private GameObject door;
    private Collider doorCollider;
    [SerializeField] private GameObject doorColliderGameObject;

    [Space]

    [Header("Lights")]   
    [SerializeField] private Light _light ;
    private Animator AfternoonAnimator; //solo referencias para animator
    
    [Space]
    //esta zona es para las camaras
    [Header("Camera")]
    [Tooltip("Camara de la objeto animado")]
    [SerializeField] private CinemachineCamera fpCamera;
    [SerializeField] private CinemachineCamera secondCamera;
    [Space]
    
    [Header("GameOver")]
    [Tooltip("Colocacion de GameOver")]
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject gameOverUI;

    //Esta variable es para juntar la corrutina en el trigger
    private IEnumerator instanciaCorrutina;
    
    private void Start()
    {
        //Aqui se unen variable y proposito
        Application.targetFrameRate = 60;
        doorAnimator = door.GetComponent<Animator>();
        AfternoonAnimator = _light.GetComponent<Animator>();
        //Se embotella en variable la corrutina para pararla
        instanciaCorrutina = DangerZoneDamage();
        //oculta y bloquea en cursor en pantalla
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;

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
                    StartCoroutine(instanciaCorrutina);
                }
                break;
            case "Health":
                if (openDoor == true)
                {
                    Health += increaseHealth;
                    healthZoneUI.SetActive(true);
                    AfternoonAnimator.SetBool("AnimAfternoon",true);
                    SwitchToNewCamera();
                    Invoke("SwitchTofpCamera", 5);
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
            case "Health":
            {
                healthZoneUI.SetActive(false);
                AfternoonAnimator.SetBool("AnimAfternoon",false);
                SwitchTofpCamera();
                break;
            }
            //desactivar ui
            case "Damage":
            {
                dangerZoneUI.SetActive(false);
                StopCoroutine(instanciaCorrutina);
                break;
            }
            
        }
        
    }
    //´Para cambiar la camara de primera a segunda, se crea un nuevo metodo personal
    private void SwitchToNewCamera()
    {
        fpCamera.Priority = 0;
        secondCamera.Priority = 10;
    }

    private void SwitchTofpCamera()
    {
        secondCamera.Priority = 0;
        fpCamera.Priority = 10;
    }

    IEnumerator DangerZoneDamage()
    {
        while (Health >= 0)
        {
            Health -= decreaseHealth;
            dangerZoneUI.SetActive(true);
            Debug.Log("Te mueres, atento CTM");
            yield return new WaitForSeconds(0.5f);
            dangerZoneUI.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }

        if (Health <= 0)
        {
            GameOver();
        }
    
        
        
    }

    private void GameOver()
    {
        gameOverUI.SetActive(true);
        //para mostrar el cursor en pantalla 
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
    public void Reset()
    {
        //reinicia el juego
        SceneManager.LoadScene("SampleScene");
    }
}
