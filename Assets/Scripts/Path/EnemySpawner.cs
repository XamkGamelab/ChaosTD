using JetBrains.Annotations;
using System.Threading;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyMovementManager movementManager;
    [SerializeField] private Enemy[] enemyTypes;

    [SerializeField] bool enableSpawnOnInterval = false;
    [SerializeField] float spawnInterval = 1f;
    float spawnTimer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int round = 1;
    public int points = 0;
    public GameObject[] enemies;

    public float roundTime = 0f;
    int amountOfSpawnables;
    int chosenSpawnable;

    public bool directorRunning = false;
    void Start()
    {
        movementManager = GetComponent<EnemyMovementManager>();
    }

    void Update()
    {
        //SpawnOnInterval();


        roundTime -= Time.deltaTime;

        //spawnInterval -= Time.deltaTime;

        if(roundTime <= 0f && directorRunning == false)
        {
            points = round * 100;
            roundTime = 30f;
            round += 1;
            directorRunning = true;
            StartCoroutine(SpawnDirector());
        }
    }

    IEnumerator SpawnDirector()
    {
        Debug.Log("Spawn Director called");
        while (points > 0)
        {
            amountOfSpawnables = enemyTypes.Length;
            reroll();
            SpawnEnemy(chosenSpawnable);
            yield return new WaitForSeconds(spawnInterval);
        }
        directorRunning = false;
    }

    public int reroll()
    {
        chosenSpawnable = Random.Range(0, amountOfSpawnables);
        return chosenSpawnable;
    }

    /*public void SpawnOnInterval()
    {
        if (spawnTimer > 0f)
            spawnTimer -= Time.deltaTime;
        else
        {
            spawnTimer = spawnInterval;
            SpawnEnemy(0);
        }
    }*/
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

        if (points >= data.cost) {
            Debug.Log("Enemy should spawn now");
            TestEnemy enemy = Instantiate(data.prefab);
            enemy.Initialize(data, movementManager);
            movementManager.AddEnemy(enemy);
            points -= data.cost;
        }
        else
        {
            
        }
    }
}
