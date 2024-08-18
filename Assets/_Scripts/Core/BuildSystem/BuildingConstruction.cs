using UnityEngine;

namespace KingdomGuardians.Core.BuildSystem
{
    public class BuildingConstruction : MonoBehaviour
    {
        [SerializeField] private GameObject _buildingPrefab;
        [SerializeField] private Transform _head;
        [SerializeField] private float _maxDistance;
        [SerializeField] private LayerMask _layers;

        public void Build()
        {
            Physics.Raycast(_head.position, _head.forward, out RaycastHit hitInfo, _maxDistance, _layers);
            
            if (hitInfo.collider != null)
                Instantiate(_buildingPrefab, hitInfo.point, Quaternion.identity);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(_head.position, _head.position + _head.forward * _maxDistance);
        }
    }
}