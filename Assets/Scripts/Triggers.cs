using System;
using Unity.VisualScripting;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    public float velocity = 4.5f;
    public bool clueFind1 = false;
    public bool clueFind2 = false;
    private bool openDoor = false;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Clue1":
                clueFind1 = true;
                Debug.Log("Recogiste la linterna");
                break;
            case "Clue2":
                clueFind2 = true;
                Debug.Log("Encontraste las pilas de la linterna, ¿pensaste que es infinita?");
                break;
            case "Door":
                if (clueFind1 && clueFind2)
                {
                    Debug.Log("Tienes las dos pistas, felicidades, aborto planeado");
                    openDoor = true;
                }
                else
                {
                    Debug.Log("¿Para que tienes este juego si nisiquiera vas a jugarlo, niño adoptado?");
                }
                break;
                
        }
    }


    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clue1"))
        {
            clueFind1 = true;
            Debug.Log("Choque con el trigger " + clueFind1);
        } 
        else if (other.CompareTag("Clue2"))
        {
            clueFind2 = true;
            Debug.Log("Choque con el trigger " + clueFind2);
        }
        else if (other.CompareTag("Door"))
        {
            if (clueFind1 == true && clueFind2 == true)
            {
                Debug.Log("Puedes abrir la puerta");
            }
            else
            {
                Debug.Log("¿Estas jugando siquiera, pedazo de mierda?");
            }
        }
        
    }*/

}
