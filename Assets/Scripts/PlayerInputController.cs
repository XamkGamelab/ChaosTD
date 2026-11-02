using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ChaosTD
{
    public class PlayerInputController : MonoBehaviour
    {

        [SerializeField] private TowerPlacementSystem placementSystem;
        private InputAction _select1Action;
        private InputAction _select2Action;
        private InputAction _placeAction;

        private void Awake()
        {
            var actionMap = InputSystem.actions.FindActionMap("PlacementSelection");

            _select1Action = actionMap.FindAction("SelectTower1");
            _select2Action = actionMap.FindAction("SelectTower2");
            _placeAction = actionMap.FindAction("PlaceTower");

            _select1Action.performed += OnSelect1Performed;
            _select2Action.performed += OnSelect2Performed;
            _placeAction.performed += OnTowerPlacePerformed;
        }

        private void OnSelect1Performed(InputAction.CallbackContext context)
        {
            if (placementSystem.selectedTower == 0)
                placementSystem.selectedTower = -1;
            else 
                placementSystem.selectedTower = 0;
        }

        private void OnSelect2Performed(InputAction.CallbackContext context)
        {
            if (placementSystem.selectedTower == 1)
                placementSystem.selectedTower = -1;
            else
                placementSystem.selectedTower = 1;
        }

        private void OnTowerPlacePerformed(InputAction.CallbackContext context)
        {
            placementSystem.PlaceTower(); 
        }

        private void OnDestroy()
        {
            _select1Action.performed -= OnSelect1Performed;
            _select2Action.performed -= OnSelect2Performed;
            _placeAction.performed -= OnTowerPlacePerformed;
        }
    }
}