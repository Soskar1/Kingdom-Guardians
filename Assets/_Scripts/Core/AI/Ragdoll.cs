using System.Collections.Generic;
using UnityEngine;

namespace KingdomGuardians.Core.AI
{
    public class Ragdoll : MonoBehaviour
    {
        [SerializeField] private List<Rigidbody> _rigidbodies = new List<Rigidbody>();

        public void Enable()
        {
            foreach (var rigidbody in _rigidbodies)
                rigidbody.isKinematic = false;
        }

        public void Push(Vector3 direction, float power, ForceMode forceMode = ForceMode.Impulse)
        {
            foreach (var rigidbody in _rigidbodies)
                rigidbody.AddForce(direction * power, forceMode);
        }

        public void Push(Vector3 velocity, ForceMode forceMode = ForceMode.Impulse) => Push(velocity, 1.0f, forceMode);
    }
}