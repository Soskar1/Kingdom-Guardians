using UnityEngine;

namespace KingdomGuardians.Core
{
    [RequireComponent(typeof(Rigidbody))]
    public class Jumping : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _force;

        public void Jump() => _rigidbody.AddForce(Vector3.up * _force, ForceMode.Impulse);
    }
}