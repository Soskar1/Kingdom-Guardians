using UnityEngine;
using UnityEngine.InputSystem;

namespace KingdomGuardians.Core
{
    [RequireComponent(typeof(PhysicsMovement))]
    [RequireComponent(typeof(PlayerRotation))]
    [RequireComponent(typeof(Jumping))]
    public class Player : MonoBehaviour
    {
        private Input _input;
        [SerializeField] private PhysicsMovement _movement;
        [SerializeField] private PlayerRotation _cameraRotation;
        [SerializeField] private Jumping _jumping;
        [SerializeField] private Transform _head;

        private void Awake() => _input = new Input();
        
        private void OnEnable()
        {
            _input.Controls.Player.Jump.performed += Jump;
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Controls.Player.Jump.performed -= Jump;
            _input.Disable();
        }

        private void Update()
        {
            _cameraRotation.Rotate(_input.DeltaMouse);
        }

        private void FixedUpdate()
        {
            Vector3 movement = _head.forward * _input.Movement.y + _head.right * _input.Movement.x;
            _movement.Move(movement);
        }

        private void Jump(InputAction.CallbackContext context)
        {
            _jumping.Jump();
        }
    }
}