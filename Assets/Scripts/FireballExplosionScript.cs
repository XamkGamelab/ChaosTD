using UnityEngine;

public class FireballExplosionScript : MonoBehaviour
{
    float timeAlive =  0.5f;
    int damage = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive -= Time.deltaTime;

        if (timeAlive <= 0.0f)
        {
            destroy();
        }
    }

    void destroy()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        TestEnemy enemy = other.GetComponent<TestEnemy>(); //MUUTA TÄÄÄ PERUS CLÄSS SKRIPTIKSI KUN KEKSIT
        if (enemy != null)
        {
            enemy.currentHP -= damage;
        }
        else
        {

        }

    }
}
