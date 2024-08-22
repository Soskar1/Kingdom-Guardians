using UnityEngine;
using UnityEngine.InputSystem;

namespace KingdomGuardians.Core.BuildSystem
{
    [RequireComponent(typeof(BuildingProjection))]
    public class BuildingConstruction : MonoBehaviour
    {
        private BuildingProjection _projection;
        private Controls _controls;

        private void Awake() => _projection = GetComponent<BuildingProjection>();

        public void Initialize(Player player, Controls controls)
        {
            _controls = controls;
            _projection.Initialize(player);
        }

        public void StartBuilding(BuildingInfo buildingInfo)
        {
            _projection.StartBuildingProjection(buildingInfo);
            _controls.Player.Build.performed += Build;
        }

        public void Build(InputAction.CallbackContext context)
        {
            _controls.Player.Build.performed -= Build;
            _projection.StopProjection();

            GameObject prefab = _projection.SelectedBuilding;
            GameObject buildingInstance = Instantiate(prefab, prefab.transform.position, Quaternion.identity);
            buildingInstance.SetActive(true);
        }
    }
}