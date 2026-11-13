using UnityEngine;

public class lasermove : ProjectileClassScript
{
    private float force = 40f;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        damage = 1;
    }
    public override void Setup(Vector3 direction)
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

        rb.AddForce(direction * force, ForceMode.Impulse);
    }
    // Update is called once per frame
    private void Update()
    {
        
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
}