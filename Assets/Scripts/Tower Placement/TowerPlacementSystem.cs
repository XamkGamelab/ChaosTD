using UnityEngine;
using UnityEngine.InputSystem;

public class TowerPlacementSystem : MonoBehaviour
{
    public GameObject[] towers;
    public int selectedTower = -1;
    private Vector3 worldPosition;
    GameObject previewObject = null;


    private bool TryGetPlacementPosition(out Vector3 position)
    {
        position = default;

        int layerMask = ~LayerMask.GetMask("IgnoreMouse");
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask)
            && hit.collider.CompareTag("Placeable"))
        {
            position = hit.point;
            return true;
        }

        return false;
    }

    void DrawPreview(Vector3 position)
    {
        if (previewObject == null)
        {
            previewObject = Instantiate(towers[selectedTower], position, towers[selectedTower].transform.rotation);
        }
        else
            previewObject.transform.position = position;
    }

    public void PlaceTower()
    {
        if (selectedTower < 0 || selectedTower >= towers.Length)
        {
            Debug.Log("No tower selected");
            return;
        }

        if (TryGetPlacementPosition(out Vector3 position))
        {
            Debug.Log(position);
            Instantiate(towers[selectedTower], position, towers[selectedTower].transform.rotation);
            selectedTower = -1;
            Debug.Log("Tower placed");
            Destroy(previewObject);
        }
        else
        {
            Debug.Log("Can't place tower");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (selectedTower >= 0)
        {
            TryGetPlacementPosition(out Vector3 position);
            DrawPreview(position);
        }
    }
}
