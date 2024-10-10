using System;
using UnityEngine;

public class HealthZoneController : MonoBehaviour
{
    [SerializeField] private GameObject healthZoneUI;
    [SerializeField] private Light directionalLight;
    private Animator SunAnimator;
    [SerializeField] private int Healthamount = 5;

    private void Start()
    {
        SunAnimator = directionalLight.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            healthZoneUI.SetActive(true);
            //Llamamos al GameManager y le enviamos la cantidad de vida a sumar
            GameManager.instance.IncreaseHealth(Healthamount);
            SunAnimator.SetBool("AnimAfternoon",true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            healthZoneUI.SetActive(false);
            SunAnimator.SetBool("AnimAfternoon", false);
        }
    }
}
