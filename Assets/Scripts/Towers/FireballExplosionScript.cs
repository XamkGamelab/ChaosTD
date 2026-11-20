using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FireballExplosionScript : MonoBehaviour
{
    float timeAlive =  0.5f;
    float damage = 3.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ExplosionDamage(transform.position,10f);
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive -= Time.deltaTime;

        if (timeAlive <= 0.0f)
        {
            destroy();
        }
    }

    void destroy()
    {
        Destroy(gameObject);
    }

    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius/2);
        foreach (var hitCollider in hitColliders)
        {
            TestEnemy enemy = hitCollider.GetComponent<TestEnemy>();
            if(enemy != null)
            {
                enemy.DoDamage(damage);
            }
        }
    }
}
