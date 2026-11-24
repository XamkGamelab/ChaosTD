using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class lasermove : ProjectileClassScript
{
    private float force = 40f;
    private Rigidbody rb;
    Vector3 dir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        damage = 1;
    }
    public override void Setup(Vector3 direction)
    {
        dir = direction;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

        rb.AddForce(direction * force, ForceMode.Impulse);
    }
    // Update is called once per frame
    private void Update()
    {
        
    }
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        GameObject hitEffect = Instantiate<GameObject>(hitParticleSystem);
        hitEffect.transform.position = gameObject.transform.position;
    //    Vector3 flatForward = Vector3.ProjectOnPlane(transform.forward, Vector3.up);
        hitEffect.transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
        ParticleSystem[] subEffects = hitEffect.GetComponentsInChildren<ParticleSystem>();
        
        //subEffects[1].transform.rotation = subEffects[0].transform.rotation;
        //hitEffect.transform.rotation = gameObject.transform.rotation;
        //if (hitEffect != null)
            subEffects[0].Play();
            subEffects[1].Play();
    }
}