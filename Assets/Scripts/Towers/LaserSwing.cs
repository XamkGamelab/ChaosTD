using UnityEngine;

public class LaserSwing : ProjectileClassScript
{
    public float offset = 0f; // SET IN INSPECTOR
    public override void Setup(Vector3 direction)
    {
        damage = 3;
        lifetime = 5f;
        force = 40f;
        rb = GetComponent<Rigidbody>();
        //First set the rotation, THEN the offset
        transform.rotation = Quaternion.FromToRotation(Vector3.forward, direction);
        transform.position += transform.forward * offset;
        AreaDamage(transform.position, transform.localScale, transform.rotation);

        rb.AddForce(direction * force, ForceMode.Impulse);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    void AreaDamage(Vector3 center, Vector3 size, Quaternion rotation)
    {
        Collider[] hitColliders = Physics.OverlapBox(center, size / 2, rotation);
        foreach (var hitCollider in hitColliders)
        {
            TestEnemy enemy = hitCollider.GetComponent<TestEnemy>();
            if (enemy != null)
            {
                enemy.DoDamage(damage);
            }
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        TestEnemy enemy = other.GetComponent<TestEnemy>();
        if (enemy != null)
        {
            enemy.DoDamage(damage);
        }
    }
}
