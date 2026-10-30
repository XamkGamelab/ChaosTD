using Unity.VisualScripting;
using UnityEngine;

public class TowerScriptRobot : MonoBehaviour
{
    public Tower data;
    private float cooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0f)
        {
            data.shoot(data.bullet, transform.position, transform.forward);
            cooldown = 1f / data.fireRate;
        }
    }
}
