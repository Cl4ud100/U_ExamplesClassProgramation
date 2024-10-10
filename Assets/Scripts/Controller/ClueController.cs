using System;
using UnityEngine;

public class ClueController : MonoBehaviour
{
    private bool Clue1Found;
    private bool Clue2Found;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Clue1":
                Clue1Found = true;
                Debug.Log("Clue1 Found");
                break;
            case "Clue2":
                Clue2Found = true;
                Debug.Log("Clue2 Found");
                break;
            
        }
    }

    public bool AllCluesCollected()
    {
        return Clue1Found && Clue2Found;
    }
}
