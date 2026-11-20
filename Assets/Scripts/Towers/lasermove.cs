using UnityEngine;

public class lasermove : ProjectileClassScript
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
    }
    public override void Setup(Vector3 direction)
    {
        lifetime = 5f;
        damage = 1;
        force = 40f;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

        rb.AddForce(direction * force, ForceMode.Impulse);
    }
    // Update is called once per frame
    private void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}