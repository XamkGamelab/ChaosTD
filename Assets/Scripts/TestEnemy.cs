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

        gameObject.name = data.enemyName;

        // Assuming size is a uniform scale multiplier.
        transform.localScale *= data.size;

        DistanceTravelled = 0f;
    }
}
