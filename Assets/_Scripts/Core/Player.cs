using UnityEngine;

namespace KingdomGuardians.Core
{
    [RequireComponent(typeof(PhysicsMovement))]
    [RequireComponent(typeof(PlayerRotation))]
    public class Player : MonoBehaviour
    {
        private Input _input;
        [SerializeField] private PhysicsMovement _movement;
        [SerializeField] private PlayerRotation _cameraRotation;

        private void Awake() => _input = new Input();
        private void OnEnable() => _input.Enable();
        private void OnDisable() => _input.Disable();

        private void Update()
        {
            _cameraRotation.Rotate(_input.DeltaMouse);
        }

        private void FixedUpdate()
        {
            _movement.Move(_input.Movement);
        }
    }
}