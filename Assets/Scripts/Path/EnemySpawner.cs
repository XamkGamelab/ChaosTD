using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyMovementManager movementManager;
    [SerializeField] private Enemy[] enemyTypes;

    [SerializeField] bool enableSpawnOnInterval = false;
    [SerializeField] float spawnInterval = 1f;
    float spawnTimer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created



    void Start()
    {
        movementManager = GetComponent<EnemyMovementManager>();
        // Spawn one enemy of the first configured type.
    }

    void Update()
    {
        SpawnOnInterval();
    }

    public void SpawnOnInterval()
    {
        if (spawnTimer > 0f)
            spawnTimer -= Time.deltaTime;
        else
        {
            spawnTimer = spawnInterval;
            SpawnEnemy(0);
        }
    }
    public void SpawnEnemy(int typeIndex)
    {

        // AI generated for debugging purposes
        if (enemyTypes == null || typeIndex < 0 || typeIndex >= enemyTypes.Length)
        {
            Debug.LogError("Enemy type index is invalid.", this);
            return;
        }

        Enemy data = enemyTypes[typeIndex];

        if (data == null)
        {
            Debug.LogError("Enemy Types element is unassigned.", this);
            return;
        }

        if (data.prefab == null)
        {
            Debug.LogError("Prefab is unassigned in " + data.name, data);
            return;
        }

        if (movementManager == null)
        {
            Debug.LogError("Movement Manager is unassigned.", this);
            return;
        }

        TestEnemy enemy = Instantiate(data.prefab);
        enemy.Initialize(data);
        movementManager.AddEnemy(enemy);
    }
}
