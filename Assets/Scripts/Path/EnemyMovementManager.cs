using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class EnemyMovementManager : MonoBehaviour
{

    [SerializeField] private SplineContainer splineContainer;
    [SerializeField] private int splineIndex;

    private readonly List<TestEnemy> activeEnemies = new List<TestEnemy>();

    private NativeSpline worldSpline;
    private float pathLength;
    private bool splineReady;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        splineContainer = GetComponent<SplineContainer>();

        if (splineContainer == null || splineIndex < 0 || 
            splineIndex >= splineContainer.Splines.Count || 
            splineContainer.Splines[splineIndex].Count < 2)
        {
            Debug.LogError("Spline is invalid");
            enabled = false;
            return;
        }

        worldSpline = new NativeSpline(splineContainer.Splines[splineIndex], 
        (float4x4)splineContainer.transform.localToWorldMatrix, 
        Unity.Collections.Allocator.Persistent);

        splineReady = true;
        pathLength = worldSpline.GetLength();

        if (pathLength > 0f)
        {
            Debug.LogError("Path length must be greater then 0");
        }


       

    }

    public void AddEnemy(TestEnemy enemy)
    {
        if (!splineReady || enemy == null)
        {
            return;
        }

        enemy.DistanceTravelled = 0f;

        ApplyTransform(enemy);

        activeEnemies.Add(enemy);
    }

    public void RemoveEnemy(TestEnemy enemy)
    {
        activeEnemies.Remove(enemy);
    }

    // Update is called once per frame
    void Update()
    {
        if (!splineReady || pathLength > 0)
            return;

            float dt = Time.deltaTime;

        for (int i = activeEnemies.Count - 1; i >= 0; i--)
        {
            TestEnemy enemy = activeEnemies[i];

            if (enemy == null)
            {
                activeEnemies.RemoveAt(i);
                continue;
            }

            enemy.DistanceTravelled = Mathf.Min(enemy.DistanceTravelled 
                + Mathf.Max(0f, enemy.currentSpeed) * dt, pathLength);

            ApplyTransform(enemy);

            if (enemy.DistanceTravelled >= pathLength)
            {
                activeEnemies.RemoveAt(i);
                HandleReachedEnd(enemy);
            }


        }


    }
    private void ApplyTransform(TestEnemy enemy)
    {
        float t = SplineUtility.ConvertIndexUnit(worldSpline, enemy.DistanceTravelled,
            PathIndexUnit.Distance, PathIndexUnit.Normalized);

        if (!SplineUtility.Evaluate(worldSpline, t, out var position, out var tangent, out var up))
        {
            return;
        }

        Transform enemyTransform = enemy.transform;
        enemyTransform.position = (Vector3)position;

        Vector3 forward = (Vector3)tangent;
        Vector3 upDirection = (Vector3)up;

        if (forward.sqrMagnitude > 0.0001f && Vector3.Cross(forward, upDirection).sqrMagnitude > 0.0001f)
        {
            enemyTransform.rotation = quaternion.LookRotation(forward, upDirection);
        }

    }


    private void HandleReachedEnd(TestEnemy enemy)
    {
        // Adjust score here later
        Destroy(enemy.gameObject);
    }
}
