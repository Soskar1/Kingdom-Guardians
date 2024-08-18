using UnityEngine;

namespace KingdomGuardians.Core
{
    [RequireComponent(typeof(Rigidbody))]
    public class Jumping : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        [SerializeField] private float _force;

        private void Awake() => _rigidbody = GetComponent<Rigidbody>();

        public void Jump() => _rigidbody.AddForce(Vector3.up * _force, ForceMode.Impulse);
    }
}