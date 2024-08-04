using UnityEngine;

namespace KingdomGuardians.Core
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _groundLayers;
        [SerializeField] private float _radius;

        public bool CheckForGround()
        {
            Collider[] colliders = Physics.OverlapSphere(_groundCheck.position, _radius, _groundLayers);

            if (colliders.Length > 0)
                return true;

            return false;
        }
    }
}