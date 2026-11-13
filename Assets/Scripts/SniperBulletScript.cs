using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SniperBulletScript : ProjectileClassScript
{

    public EnemyMovementManager spawner;
    public float target;
    float timeAlive = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        damage = 5;
        spawner = FindFirstObjectByType<EnemyMovementManager>(FindObjectsInactive.Include);
        if (spawner.GetFirstEnemy() != null)
        {
            target = spawner.GetFirstEnemy().currentHP; // Get the transform of the first enemy in list
            spawner.GetFirstEnemy().currentHP -= damage;
            if (spawner.GetFirstEnemy().currentHP <= 0)
            {
                Destroy(spawner.GetFirstEnemy());
            }

        }
        else
        {
            //Do nothing
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spawner.GetFirstEnemy().currentHP <= 0)
        {
            Destroy(spawner.GetFirstEnemy());
        }

        timeAlive -= Time.deltaTime;

        if (timeAlive <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
    public override void Setup(Vector3 direction)
    {
        
    }
    }
