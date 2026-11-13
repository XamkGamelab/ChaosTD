using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[CreateAssetMenu(fileName = "EnemyClassScript", menuName = "Scriptable Objects/EnemyClassScript")]
public class Enemy : ScriptableObject
{
    public float HP;
    public int damage;
    public string enemyName;
    public float size;
    public float speed;
    public float armor;
    public int score;
    public TestEnemy prefab;
}
