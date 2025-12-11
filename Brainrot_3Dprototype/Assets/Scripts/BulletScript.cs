using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float damage;
    public float lifeTime = 3f;

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
        Destroy(gameObject);
    }
}
