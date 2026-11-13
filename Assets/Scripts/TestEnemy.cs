using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public float currentHP;
    public int damage;
    public float currentSpeed;
    public float armor;
    public float DistanceTravelled { get; set; }

    public void Initialize(Enemy data)
    {
        
        currentHP = data.HP;
        damage = data.damage;
        currentSpeed = data.speed;
        armor = data.armor;
        Debug.Log("Enemy Spawned");
        gameObject.name = data.enemyName;

        // Assuming size is a uniform scale multiplier.
        transform.localScale *= data.size;
        DistanceTravelled = 0f;
    }

    public int GetDamage()
    {
        return damage;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("Enemy " + name + " died!");
    }
}
