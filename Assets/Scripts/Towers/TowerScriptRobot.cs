using Unity.VisualScripting;
using UnityEngine;

public class TowerScriptRobot : MonoBehaviour
{
    public Tower data;
    private float cooldown = 0;

    public Transform target;

    //Reference to script
    public EnemyMovementManager spawner;


    

    public void shoot(GameObject bulletPrefab, Vector3 position, Vector3 direction)
    {
        GameObject instance = Instantiate(bulletPrefab, position, Quaternion.identity);
        instance.GetComponent<ProjectileClassScript>().Setup(direction);
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawner = FindFirstObjectByType<EnemyMovementManager>(FindObjectsInactive.Include);
    }

    // Update is called once per frame
    void Update()
    {
        target = null;

        //FindTarget(transform.position, data.range);
        if (spawner.GetFirstEnemy() != null)
        {
            foreach (TestEnemy enemy in spawner.GetEnemyList())
            {
                if (Vector3.Distance(transform.position, enemy.transform.position) < data.range)
                {
                    //Source: Code Monkey
                    target = enemy.transform;
                    break;
                }
            }
            if(target != null)
            {
                transform.LookAt(target); //Look at the targeted enemy
                Vector3 kulmat = transform.eulerAngles;
                kulmat.x = 0f;
                kulmat.z = 0f;
                transform.eulerAngles = kulmat;
                if (cooldown <= 0f)
                {
                    shoot(data.bullet, transform.position, transform.forward);
                    cooldown = 1f / data.fireRate;
                }
            }
            else{
                //Do nothing
            }
            
        }

        else
        {
            //Do nothing
        }
        cooldown -= Time.deltaTime; // Cooldown for shooting
    }
}


