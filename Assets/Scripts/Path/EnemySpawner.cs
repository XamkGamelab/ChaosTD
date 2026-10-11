using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyMovementManager movementManager;
    [SerializeField] private EnemyClassScript[] enemyTypes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        // Spawn one enemy of the first configured type.
        SpawnEnemy(0);
    }

    public void SpawnEnemy(int typeIndex)
    {
        if (typeIndex < 0 || typeIndex >= enemyTypes.Length)
            return;

        EnemyClassScript data = enemyTypes[typeIndex];

        TestEnemy enemy = Instantiate(data.prefab);

        // Initialize its stats using your existing enemy setup.
        enemy.currentSpeed = data.speed;

        // Add the spawned instance to the path.
        movementManager.AddEnemy(enemy);
    }
}
