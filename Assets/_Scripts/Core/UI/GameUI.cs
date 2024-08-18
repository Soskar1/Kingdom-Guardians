using UnityEngine;
using UnityEngine.InputSystem;

namespace KingdomGuardians.Core.UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private BuildingUI _buildingUI;
        private Controls _controls;

        public void Initialize(Controls controls, PlayerRotation playerRotation)
        {
            _buildingUI.Initialize(playerRotation);

            _controls = controls;
            _controls.Player.BuildingUI.performed += HandleBuildingUI;
        }

        private void OnDisable() => _controls.Player.BuildingUI.performed -= HandleBuildingUI;

        private void HandleBuildingUI(InputAction.CallbackContext context)
        {
            if (_buildingUI.gameObject.activeSelf)
                _buildingUI.Close();
            else
                _buildingUI.Open();
        }
    }
}