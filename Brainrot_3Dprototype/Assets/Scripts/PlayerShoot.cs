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

    [Header("Key codes")]
    public KeyCode shootKey;
    public KeyCode weaponType;


    private float timer;

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime / fireRate; //This makes it so that the player will shoot at whatever the fire rate is per second, e.g. if the fire rate is 0.5, then it will shoot 2 bullets per second
        }

        if (Input.GetKeyDown(weaponType))
        {
            if (isAuto == false)
            {
                isAuto = true;
            }
            else
            {
                isAuto = false;
            }
        }

        if (isAuto)
        {
            if (Input.GetKey(shootKey) && timer <= 0) //Happens even when the key is held down
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetKeyDown(shootKey) && timer <= 0) //Only happens when the key is clicked
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnTransform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnTransform.forward * bulletSpeed, ForceMode.Impulse); //The impulse force mode makes sure that the force added to the bullet is instant
        bullet.GetComponent<BulletScript>().damage = bulletDamage; //Gets the damage from the bullet script and assigns it 

        timer = 1; //This resets the timer back to one
    }
}
