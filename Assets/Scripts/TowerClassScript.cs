using UnityEngine;

[CreateAssetMenu(fileName = "TowerClassScript", menuName = "Scriptable Objects/TowerClassScript")]
public class TowerClassScript : ScriptableObject
{
    public float range;
    public float damage;
    public float fireRate;
    public int cost;
    public float size;
    public string towerName;
    public string description;
}