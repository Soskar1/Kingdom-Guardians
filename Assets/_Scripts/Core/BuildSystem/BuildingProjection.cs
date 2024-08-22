using System.Collections.Generic;
using UnityEngine;

namespace KingdomGuardians.Core.BuildSystem
{
    public class BuildingProjection : MonoBehaviour
    {
        [SerializeField] private LayerMask _layers;
        private Transform _head;
        private GameObject _selectedBuilding;
        private bool _canProject = false;

        private Dictionary<string, GameObject> _buildings = new Dictionary<string, GameObject>();

        public void Initialize(Player player) => _head = player.Head;

        private void Update()
        {
            if (!_canProject)
                return;

            Physics.Raycast(_head.position, _head.forward, out RaycastHit hitInfo, Mathf.Infinity, _layers);
            if (hitInfo.collider != null)
                _selectedBuilding.transform.position = hitInfo.point;
        }

        public void StartBuildingProjection(BuildingInfo buildingInfo)
        {
            _selectedBuilding = GetGameObject(buildingInfo);
            _canProject = true;
        }

        private GameObject GetGameObject(BuildingInfo buildingInfo)
        {
            GameObject building;

            if (_buildings.ContainsKey(buildingInfo.name))
            {
                building = _buildings[buildingInfo.name];
            }
            else
            {
                building = Instantiate(buildingInfo.prefab, transform.position, Quaternion.identity);
                _buildings[buildingInfo.name] = building;

                building.transform.parent = transform;
            }

            return building;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(_head.position, _head.position + _head.forward * Mathf.Infinity);
        }
    }
}