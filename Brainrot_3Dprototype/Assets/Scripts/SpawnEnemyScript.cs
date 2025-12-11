using UnityEngine;

public class SpawnEnemyScript : MonoBehaviour
{
    public GameObject followEnemyPrefab; //This is the object that I want to spawn in
    public Vector3 spawnPosition; //This will select where I want to spawn the prefab


    public void SpawnEnemy()
    {
        Instantiate(followEnemyPrefab, spawnPosition, Quaternion.identity); //Instantiates the prefab by getting the GameObject, it's position and the Quaternion.identity gives it no rotation
    }
}
