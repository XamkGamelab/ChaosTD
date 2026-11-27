using UnityEditor;
using UnityEngine;

public abstract class ProjectileClassScript : MonoBehaviour
{
    //Tää clässi tehtiin alunperin sen takia että tarvitaan vaan yksi torni skripti joka kutsuu yhtä ammus scriptiä, joka sitten dynaamisesti twerkkaa
    public abstract void Setup(Vector3 direction);

    public float damage;

    public float lifetime;

    public float force;

    public Rigidbody rb;

    [SerializeField] protected GameObject hitParticleSystem;


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

    protected virtual void OnTriggerEnter(Collider other)
    {
        TestEnemy enemy = other.GetComponent<TestEnemy>(); //MUUTA TÄÄÄ PERUS CLÄSS SKRIPTIKSI KUN KEKSIT
        if (enemy != null)
        {
            Debug.Log("On lihava");
            enemy.DoDamage(damage);
            Destroy(gameObject);
        }
        else
        {
              
        }

    }
}
