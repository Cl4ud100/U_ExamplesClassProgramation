using System;
using UnityEngine;

public class Clase1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() // Metodo
    {
        //<--- esto es un mensaje que no se imprime
        Debug.Log("Impresion por Start");
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Hola Mundo, hola july");
    }

    private void OnTriggerEnter(Collider other)
    {
        //throw new NotImplementedException();
        Debug.Log("Prender Foco");
    }

    private void OnTriggerExit(Collider other)
    {
        //throw new NotImplementedException();
        Debug.Log("Apaga la luz");
    }
}
