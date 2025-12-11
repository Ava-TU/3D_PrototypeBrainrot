using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class InteractionScript : MonoBehaviour
{
    public UnityEvent enteredTrigger, exitedTrigger, interacted; 

    private bool insideTrigger; //Checks if the player is inside the triggers collider

    [Header("Keybinds")]
    public KeyCode interactKey;

    // Update is called once per frame
    void Update()
    {
        if (insideTrigger && Input.GetKeyDown(interactKey)) //If the player presses the chosen key, it will invoke the events that are in the Interacted group
        {
            interacted?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enteredTrigger.Invoke();
            insideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            exitedTrigger.Invoke();
            insideTrigger = false;
        }
    }
}