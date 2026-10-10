using UnityEngine;
using UnityEngine.InputSystem;

public class TowerPlacementSystem : MonoBehaviour
{
    public GameObject tower;
    
    public void SelectTower()
    {
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SelectTower();
    }


    // Update is called once per frame
    void Update()
    {
        int layerMask = ~LayerMask.GetMask("IgnoreMouse");

        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.CompareTag("Placeable"))
            {
                Vector3 worldPosition = hit.point;

                Debug.Log(worldPosition);
                tower.transform.position = worldPosition;
            }

        }
    }
}
