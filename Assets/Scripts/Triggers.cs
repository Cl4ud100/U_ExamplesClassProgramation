using System;
using Unity.VisualScripting;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    public float velocity = 4.5f;
    public bool clueFind1 = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clue1"))
        {
            Debug.Log("Choque con el trigger " + clueFind1);
        }
    }
}
