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

        if (spawner.GetFirstEnemy() != null)
        {

            target = spawner.GetFirstEnemy().transform; // Get the transform of the first enemy in list
            transform.LookAt(target); //Look at the first enemy
            Vector3 kulmat = transform.eulerAngles;
            kulmat.x = 0f;
            kulmat.z = 0f;
            transform.eulerAngles = kulmat;
            cooldown -= Time.deltaTime; // Cooldown for shooting
            if (cooldown <= 0f)
            {
                shoot(data.bullet, transform.position, transform.forward);
                cooldown = 1f / data.fireRate;
            }
        }
        else
        {
            //Do nothing
        }

    }
}
