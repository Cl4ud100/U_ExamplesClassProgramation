using UnityEngine;

public class GameManager : MonoBehaviour
    //Siempre Publico
//Static porque vivira en todas las vidas del juego
//y en todas sus escenas
//porque GameManager?
//porque hace referencia a nuestra clase Gamemanager
//instance en el nombre
{
    public static GameManager instance;
    
    public int health = 100;
    //*
    /* Metodo Awake, se llama una vez y antes del start
     */
    private void Awake() //Patron Singlenton
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void IncreaseHealth(int amount)
    {
        health += amount;
        Debug.Log("Health Increased" + health);
    }

    public void DecreaseHealth(int amount)
    {
        health -= amount;
        Debug.Log("Health Decreased" + health);
    }
}
