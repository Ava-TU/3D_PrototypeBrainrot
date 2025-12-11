using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemyScript : MonoBehaviour
{
    public GameObject prefab; //This is the object that I want to spawn in
    public Transform spawnPosition; //This will select where I want to spawn the prefab
    //If i wanted to chose a specific position, making a Vector3 variable would allow me to change the transforms X,Y and Z position in the inspector

    public int prefabCount; //This will be used to store the amount of prefabs that have been spawned into the scene


    public void SpawnEnemy()
    {
        Instantiate(prefab, spawnPosition.position, Quaternion.identity); //Instantiates the prefab by getting the GameObject, it's position and the Quaternion.identity uses the rotation thats used in the prefab
        prefabCount += 1; //Adds 1 to the count variable
    }
}
