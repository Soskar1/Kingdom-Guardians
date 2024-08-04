using UnityEngine;

namespace KingdomGuardians.Core
{
    [RequireComponent(typeof(Rigidbody))]
    public class PhysicsMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _decceleration;
        [SerializeField] private float _velocityPower;

        public void Move(Vector3 direction)
        {
            Vector3 targetVelocity = direction.normalized * _maxSpeed * Time.fixedDeltaTime;
            Vector3 velocityDifference = targetVelocity - _rigidbody.velocity;
            float accelerationRate = velocityDifference.magnitude > Mathf.Epsilon ? _acceleration : _decceleration;
            float movementX = Mathf.Pow(Mathf.Abs(velocityDifference.x) * accelerationRate, _velocityPower) * Mathf.Sign(velocityDifference.x);
            float movementZ = Mathf.Pow(Mathf.Abs(velocityDifference.z) * accelerationRate, _velocityPower) * Mathf.Sign(velocityDifference.z);

            _rigidbody.AddForce(new Vector3(movementX, 0.0f, movementZ));
        }
    }
}