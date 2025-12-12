using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float damage;
    public float lifeTime = 3f;

    public AudioSource enemyHit;

    private void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyScript>() != null)
        {
            other.GetComponent<EnemyScript>().health -= damage;
            enemyHit.Play();
        }
        Destroy(gameObject);
    }
}
