using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Splines;


public class EnemySplineManager : MonoBehaviour
{
    [SerializeField] private EnemyClassScript[] enemyTypes;

    private List<GameObject> activeEnemies = new List<GameObject>();

    public SplineContainer splineContainer;
    public Spline mainPath;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void SpawnEnemy(EnemyClassScript data)
    {
        
    }
    void Start()
    {
        splineContainer = GetComponent<SplineContainer>();
        mainPath = splineContainer.Splines[0];
    }
    void SetEnemyLocation( Spline splinePath)
    {
    }
    void IterateEnemies()
    {
        for (int i = 0; i < 1; i++)
        {
            SetEnemyLocation( mainPath);
        }
    }

// Update is called once per frame
void Update()

    {
        IterateEnemies();

    }
    


}
