using UnityEngine;

public class DoorAnimScript : MonoBehaviour
{
    public Animator doorAnim;
    public bool doorClose;
    public bool doorOpen;
    private bool insideTrigger;

    [Header("Keybinds")]
    public KeyCode interactKey;

    private void Start()
    {
        doorClose = true;
        doorOpen = false;
    }

    private void Update()
    {
        if (insideTrigger && Input.GetKeyDown(interactKey))
        {
            if (doorClose)
            {
                doorAnim.Play("DoorOpenAnim");
                doorOpen = true;
                doorClose = false;
            }
            else
            {
                doorAnim.Play("DoorCloseAnim");
                doorOpen = false;
                doorClose = true;
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insideTrigger = false;
        }
    }
}
