using UnityEngine;

namespace KingdomGuardians.Core
{
    [RequireComponent(typeof(Rigidbody))]
    public class Gravity : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        [SerializeField] private float _force;

        private void Awake() => _rigidbody = GetComponent<Rigidbody>();

        public void Apply() => _rigidbody.AddForce(Vector3.down * _force);
    }
}