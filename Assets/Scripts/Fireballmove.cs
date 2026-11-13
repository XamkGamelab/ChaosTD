using UnityEngine;

public class Fireballmove : ProjectileClassScript
{
    private float force = 40f;
    private Rigidbody rb;

    bool isQuitting;

    public GameObject explosion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        damage = 0;
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

    void OnApplicationQuit()
    {
        isQuitting = true;
    }
    void OnDestroy()
    {
        if (isQuitting == false)
        {   //Tutki vähän sitä että tekeekö se oikeasti AOE damagea vaiko ei?
            Instantiate(explosion, transform.position, transform.rotation = Quaternion.identity);
        }
    }
}
