using UnityEngine;

namespace KingdomGuardians.Core
{
    [RequireComponent(typeof(PhysicsMovement))]
    public class Player : MonoBehaviour
    {
        private Input _input;
        [SerializeField] private PhysicsMovement _movement;

        private void Awake() => _input = new Input();
        private void OnEnable() => _input.Enable();
        private void OnDisable() => _input.Disable();

        private void FixedUpdate()
        {
            _movement.Move(_input.ReadMovement());
        }
    }
}