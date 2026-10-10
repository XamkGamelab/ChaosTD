using UnityEngine;

[CreateAssetMenu(fileName = "EnemyClassScript", menuName = "Scriptable Objects/EnemyClassScript")]
public class EnemyClassScript : ScriptableObject
{
    public float HP;
    public int damage;
    public string enemyName;
    public float size;
    public float speed;
    public float armor;
}
