using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyMovementManager movementManager;
    [SerializeField] private EnemyClassScript[] enemyTypes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        movementManager = GetComponent<EnemyMovementManager>();
        // Spawn one enemy of the first configured type.
        SpawnEnemy(0);
    
    }

    public void SpawnEnemy(int typeIndex)
    {

        // AI generated for debugging purposes
        if (enemyTypes == null || typeIndex < 0 || typeIndex >= enemyTypes.Length)
        {
            Debug.LogError("Enemy type index is invalid.", this);
            return;
        }

        EnemyClassScript data = enemyTypes[typeIndex];

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
        enemy.currentSpeed = data.speed;
        movementManager.AddEnemy(enemy);
    }
}
