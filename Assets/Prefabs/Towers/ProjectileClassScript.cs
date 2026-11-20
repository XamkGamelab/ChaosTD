using UnityEngine;

public abstract class ProjectileClassScript : MonoBehaviour
{
    //Tää clässi tehtiin alunperin sen takia että tarvitaan vaan yksi torni skripti joka kutsuu yhtä ammus scriptiä, joka sitten dynaamisesti twerkkaa
    public abstract void Setup(Vector3 direction);

    public float damage;

    public ParticleSystem ps;

    public float force;
    public Rigidbody rb;

    public float lifetime = 5f;

    public bool isAwake;

    Collider Collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnTriggerEnter(Collider other)
    {
        TestEnemy enemy = other.GetComponent<TestEnemy>(); //MUUTA TÄÄÄ PERUS CLÄSS SKRIPTIKSI KUN KEKSIT
        if (enemy != null)
        {
            enemy.DoDamage(damage);

            ParticleSystem hitEffect = Instantiate<ParticleSystem>(ps);
            hitEffect.transform.position = gameObject.transform.position;
            //hitEffect.transform.rotation = gameObject.transform.rotation;
            if (hitEffect != null)
                hitEffect.Play(true);

            Destroy(gameObject);
        }
        else
        {
              
        }

    }
}
