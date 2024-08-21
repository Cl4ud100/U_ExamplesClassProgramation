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
        
    }


}
