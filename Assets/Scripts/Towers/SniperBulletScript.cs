using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SniperBulletScript : ProjectileClassScript
{

    public EnemyMovementManager spawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lifetime = 2;
        damage = 5;
        spawner = FindFirstObjectByType<EnemyMovementManager>(FindObjectsInactive.Include);
        if (spawner.GetFirstEnemy() != null)
        {
            TestEnemy target = spawner.GetFirstEnemy(); // Get the transform of the first enemy in list
            target.DoDamage(damage);

        }
        else
        {
            //Do nothing
        }
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
    public override void Setup(Vector3 direction)
    {
        
    }
}