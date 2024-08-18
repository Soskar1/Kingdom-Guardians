using UnityEngine;
using UnityEngine.InputSystem;

namespace KingdomGuardians.Core
{
    [RequireComponent(typeof(PhysicsMovement))]
    [RequireComponent(typeof(PlayerRotation))]
    [RequireComponent(typeof(Jumping))]
    [RequireComponent(typeof(GroundCheck))]
    [RequireComponent(typeof(Gravity))]
    public class Player : MonoBehaviour
    {
        private PhysicsMovement _movement;
        private PlayerRotation _cameraRotation;
        private Jumping _jumping;
        private GroundCheck _groundCheck;
        private Gravity _gravity;
        private Input _input;
        [SerializeField] private Transform _head;

        private void Awake()
        {
            _movement = GetComponent<PhysicsMovement>();
            _cameraRotation = GetComponent<PlayerRotation>();
            _jumping = GetComponent<Jumping>();
            _groundCheck = GetComponent<GroundCheck>();
            _gravity = GetComponent<Gravity>();
        }

        public void Initialize(Input input)
        {
            _input = input;
            _input.Controls.Player.Jump.performed += Jump;
        }

        private void OnEnable()
        {
            if (_input != null)
                _input.Controls.Player.Jump.performed += Jump;
        }

        private void OnDisable() => _input.Controls.Player.Jump.performed -= Jump;

        private void Update()
        {
            _cameraRotation.Rotate(_input.DeltaMouse);

            // TODO: Maybe there is a much better way to handle it...
            if (!_groundCheck.CheckForGround())
                _gravity.Apply();
        }

        private void FixedUpdate()
        {
            Vector3 movement = _head.forward * _input.Movement.y + _head.right * _input.Movement.x;
            _movement.Move(movement);
        }

        private void Jump(InputAction.CallbackContext context)
        {
            if (_groundCheck.CheckForGround())
                _jumping.Jump();
        }
    }
}