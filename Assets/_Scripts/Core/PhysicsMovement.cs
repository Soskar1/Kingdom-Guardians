using UnityEngine;

namespace KingdomGuardians.Core
{
    public class PhysicsMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _decceleration;
        [SerializeField] private float _velocityPower;

        public void Move(Vector2 direction)
        {
            //_rigidbody.AddForce(new Vector3(direction.x, 0.0f, direction.y) * _speed * Time.fixedDeltaTime);

            Vector2 targetVelocity = direction * _maxSpeed * Time.fixedDeltaTime;
            Vector2 velocityDifference = new Vector2(
                targetVelocity.x - _rigidbody.velocity.x,
                targetVelocity.y - _rigidbody.velocity.z);

            //float velocityDifference = targetVelocity.x - _rigidbody.velocity.x;
            //float accelerationRate = (Mathf.Abs(targetVelocity.x) > Mathf.Epsilon) ? _acceleration : _decceleration;
            float accelerationRate = velocityDifference.magnitude > Mathf.Epsilon ? _acceleration : _decceleration;

            float movementX = Mathf.Pow(Mathf.Abs(velocityDifference.x) * accelerationRate, _velocityPower) * Mathf.Sign(velocityDifference.x);
            float movementZ = Mathf.Pow(Mathf.Abs(velocityDifference.y) * accelerationRate, _velocityPower) * Mathf.Sign(velocityDifference.y);

            _rigidbody.AddForce(new Vector3(movementX, 0.0f, movementZ));
        }
    }
}