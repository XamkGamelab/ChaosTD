using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public float currentHP;
    public int damage;
    public float currentSpeed;
    public float armor;
    public int score;

    public EnemyMovementManager movementManager;
    public float DistanceTravelled { get; set; }

    public void Initialize(Enemy data, EnemyMovementManager mvmntMngr)
    {

        currentHP = data.HP;
        currentSpeed = data.speed;
        armor = data.armor;
        gameObject.name = data.enemyName;
        score = data.score;

        movementManager = mvmntMngr;  // For destruction

        transform.localScale *= data.size;  // Assuming size is uniform

        DistanceTravelled = 0f;
    }

    public int GetDamage()
    {
        return damage;
    }

    public void DoDamage(int damage) // Damage is a positive value
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            movementManager.RemoveEnemy(this, true);
        }

    }

    

    private void OnDestroy()
    {
        Debug.Log("Enemy " + name + " died!");
        Destroy(gameObject);
    }
}
