using UnityEngine;

public class SwingScript : ProjectileClassScript
{
    private float force = 0f;
    public float offset = 2f;
    public override void Setup(Vector3 direction)
    {

        transform.rotation = Quaternion.FromToRotation(Vector3.forward ,direction);

    }
    void Start()
    {
        damage = 2;
        transform.position += transform.forward * offset;
    }

    public void OnTriggerEnter(Collider other)
    {
        TestEnemy enemy = other.GetComponent<TestEnemy>(); //MUUTA TÄÄÄ PERUS CLÄSS SKRIPTIKSI KUN KEKSIT
        if (enemy != null)
        {
            enemy.DoDamage(damage);
            Destroy(gameObject);
        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
