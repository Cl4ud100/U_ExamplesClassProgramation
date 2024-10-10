using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ButtonStartGame()
    {
        SceneManager.LoadScene("Game_Stage_01");
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void ButtonRestartGame()
    {
        GameManager.instance.restartHealth();
        SceneManager.LoadScene("Game_Stage_01");
    }

    public void MenuGame()
    {
        SceneManager.LoadScene("Menu_Main");
    }
}
