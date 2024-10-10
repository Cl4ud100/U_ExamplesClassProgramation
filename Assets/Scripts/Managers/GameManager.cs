using UnityEngine;
using UnityEngine.SceneManagement;

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
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Game Manager already Destroyed");
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
        if (health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("Game_Over");
        Cursor.lockState = CursorLockMode.None;
    }

    public void restartHealth()
    {
        health = 100;
        Cursor.lockState = CursorLockMode.Locked;

    }
}
