using UnityEngine;

namespace KingdomGuardians.Core.AI.Building
{
    [RequireComponent(typeof(Rigidbody))]
    public class CannonBall : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Vector3 _pushVelocity;

        private void Awake() => _rigidbody = GetComponent<Rigidbody>();

        public void Push(Vector3 direction)
        {
            _rigidbody.AddForce(direction, ForceMode.Impulse);
            _pushVelocity = direction;
        }

        private void OnCollisionEnter(Collision collision)
        {
            Enemy enemy = collision.gameObject.GetComponentInParent<Enemy>();

            if (enemy != null && !enemy.IsRagdoll)
            {
                enemy.TurnToRagdoll();
                
                Vector3 velocityToAdd = _pushVelocity * 2f;
                enemy.GetComponent<Ragdoll>().Push(velocityToAdd);
                _rigidbody.velocity = velocityToAdd;
            }
        }
    }
}
