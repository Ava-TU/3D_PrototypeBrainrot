using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX; //This will let me adjust the camera sensitivity on the X and Y axis
    public float sensY;

    public Transform orientation; //This will find the players orientation in the scene

    float xRotation; //For the cameras rotation
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //This locks the cursor to the middle of the screen
        Cursor.visible = false; //This makes the cursor invisable to be less distracting
    }

    private void Update()
    {
        //Getting the mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;

        //Stopping the player from being able to look to far up and down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Clamps the X axis to only go between 90 and -90 degrees

        //Rotate camera and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); //Rotates the camera on both the X and Y axis
        orientation.rotation = Quaternion.Euler(0, yRotation, 0); //Rotates the player with the camera only on the Y-axis

    }
}
