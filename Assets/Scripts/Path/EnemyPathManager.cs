using UnityEditor;
using UnityEngine;
using UnityEngine.Splines;

[System.Serializable]

public class EnemySplineManager : MonoBehaviour
{
    public struct EnemyData
    {
        public GameObject enemy;

        public string name;
        public float position;
        private float speed;
        private float health;

        void Initialize()
        {
            //TEMP
            speed = 5f;
            health = 10f;
        }


    }
    [SerializeField]
    public EnemyData[] enemyData;

    public SplineContainer splineContainer;
    public Spline mainPath;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        splineContainer = GetComponent<SplineContainer>();
        mainPath = splineContainer.Splines[0];
    }
    void SetEnemyLocation(EnemyData eData, Spline splinePath)
    {
        eData.name = "Hello, world";
    }
    void IterateEnemies()
    {
        for (int i = 0; i < enemyData.Length; i++)
        {
            SetEnemyLocation(enemyData[i], mainPath);
        }
    }

// Update is called once per frame
void Update()

    {
        IterateEnemies();

    }
    


}
