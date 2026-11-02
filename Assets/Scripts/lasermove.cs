using UnityEngine;

public class lasermove : MonoBehaviour
{
    private GameObject shooterTower;
    private Vector3 direction;
    private float force = 40f;
    private Rigidbody rb;

    Collider Collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        Collider = GetComponent<Collider>();
    }
    public void Setup(Vector3 direction)
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
}