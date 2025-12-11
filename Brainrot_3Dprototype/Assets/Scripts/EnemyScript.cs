using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private Transform cameraTransform; //Stores the reference to the camera I want the enemy to always be facing

    public float health;


    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(cameraTransform); //Makes the game object look towards the camera
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0); //Only allows the object to rotate on the Y-axis

        if (health <= 0) //If the enemies health is below or equal to 0, it destroys itself.
        {
            Destroy(gameObject);
        }
    }


}
