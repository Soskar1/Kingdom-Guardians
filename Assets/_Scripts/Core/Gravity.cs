using UnityEngine;

namespace KingdomGuardians.Core
{
    [RequireComponent(typeof(Rigidbody))]
    public class Gravity : MonoBehaviour
    {
        [SerializeField] private float _force;
        [SerializeField] private Rigidbody _rigidbody;

        public void Apply() => _rigidbody.AddForce(Vector3.down * _force);
    }
}