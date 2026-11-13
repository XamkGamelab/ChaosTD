using UnityEngine;

public abstract class ProjectileClassScript : MonoBehaviour
{
    //Tää clässi tehtiin alunperin sen takia että tarvitaan vaan yksi torni skripti joka kutsuu yhtä ammus scriptiä, joka sitten dynaamisesti twerkkaa
    public abstract void Setup(Vector3 direction);

    public int damage;

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
            enemy.currentHP -= damage;
            Destroy(gameObject);
        }
        else
        {
              
        }

    }
}
