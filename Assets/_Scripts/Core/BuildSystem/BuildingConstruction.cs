using UnityEngine;
using UnityEngine.InputSystem;

namespace KingdomGuardians.Core.BuildSystem
{
    [RequireComponent(typeof(BuildingProjection))]
    public class BuildingConstruction : MonoBehaviour
    {
        private BuildingProjection _projection;
        private Input _input;

        private void Awake() => _projection = GetComponent<BuildingProjection>();

        private void OnDisable() => _input.Controls.Player.Build.performed -= Build;

        public void Initialize(Player player, Input input)
        {
            _input = input;
            _projection.Initialize(player, input);
        }

        public void StartBuilding(BuildingInfo buildingInfo)
        {
            _projection.StartBuildingProjection(buildingInfo);
            _input.Controls.Player.Build.performed += Build;
        }

        public void Build(InputAction.CallbackContext context)
        {
            _input.Controls.Player.Build.performed -= Build;
            _projection.StopProjection();

            GameObject prefab = _projection.SelectedBuilding;
            GameObject buildingInstance = Instantiate(prefab, prefab.transform.position, prefab.transform.rotation);
            buildingInstance.SetActive(true);
        }
    }
}