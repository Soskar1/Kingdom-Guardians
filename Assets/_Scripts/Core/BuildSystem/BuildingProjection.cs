using System.Collections.Generic;
using UnityEngine;

namespace KingdomGuardians.Core.BuildSystem
{
    public class BuildingProjection : MonoBehaviour
    {
        [SerializeField] private LayerMask _layers;
        [SerializeField] private float _rotationSpeed;
        private Input _input;
        private Transform _head;
        private GameObject _selectedBuilding;
        private bool _canProject = false;

        private Dictionary<string, GameObject> _buildings = new Dictionary<string, GameObject>();

        public GameObject SelectedBuilding => _selectedBuilding;

        public void Initialize(Player player, Input input)
        {
            _head = player.Head;
            _input = input;
        }

        private void Update()
        {
            if (!_canProject)
                return;

            Physics.Raycast(_head.position, _head.forward, out RaycastHit hitInfo, Mathf.Infinity, _layers);
            if (hitInfo.collider != null)
                _selectedBuilding.transform.position = hitInfo.point;

            if (_input.Scroll > 0)
                _selectedBuilding.transform.Rotate(Vector3.up, _rotationSpeed);
            else if (_input.Scroll < 0)
                _selectedBuilding.transform.Rotate(Vector3.up, -_rotationSpeed);
        }

        public void StartBuildingProjection(BuildingInfo buildingInfo)
        {
            _selectedBuilding = GetGameObject(buildingInfo);
            _selectedBuilding.transform.rotation = Quaternion.identity;
            _selectedBuilding.SetActive(true);
            _canProject = true;
        }

        public void StopProjection()
        {
            _selectedBuilding.SetActive(false);
            _canProject = false;
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
    }
}