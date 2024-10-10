using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private GameObject dangerZoneUI;
    [SerializeField] private int HealthDecreased = 10 ; //Para modificar en unity, sin entrar en el scripts
    private IEnumerator instanciaCorrutina;
    private void Start()
    {
        instanciaCorrutina = DangerZone();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(instanciaCorrutina);
        }
    }

    IEnumerator DangerZone()
    {
        while (GameManager.instance.health >= 0)
        {
            dangerZoneUI.SetActive(true);
            GameManager.instance.DecreaseHealth(HealthDecreased);
            Debug.Log("Te estas muriendo Conchetumadre");
            yield return new WaitForSeconds(2);
            dangerZoneUI.SetActive(false);
            yield return new WaitForSeconds(2);
        }

        if (GameManager.instance.health <= 0)
        {
            SceneManager.LoadScene("Game_Over");
        }
    }

    private void OnTriggerExit(Collider other)
    {   
        dangerZoneUI.SetActive(false);
        StopCoroutine(instanciaCorrutina);
        
    }


}
