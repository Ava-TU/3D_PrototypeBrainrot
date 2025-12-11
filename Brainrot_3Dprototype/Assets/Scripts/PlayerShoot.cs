using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [Header("Bullet Variables")]
    public float bulletSpeed; //How fast the bullets move
    public float fireRate, bulletDamage;
    public bool isAuto; //This will toggle if the gun is automatic or not

    [Header("Initial Setup")]
    public Transform bulletSpawnTransform; //This is where the bullets will spawn from
    public GameObject bulletPrefab; //This calls the bullets prefab
    public KeyCode shootKey;

    private void Update()
    {
        if (isAuto)
        {
            if (Input.GetKey(shootKey)) //Happens even when the key is held down
            {

            }
        }
        else
        {
            if (Input.GetKeyDown(shootKey)) //Only happens when the key is clicked
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnTransform.position, Quaternion.identity);
    }
}
