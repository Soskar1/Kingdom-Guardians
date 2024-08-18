using KingdomGuardians.Core.BuildSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KingdomGuardians.Core
{
    [RequireComponent(typeof(PhysicsMovement))]
    [RequireComponent(typeof(PlayerRotation))]
    [RequireComponent(typeof(Jumping))]
    [RequireComponent(typeof(GroundCheck))]
    [RequireComponent(typeof(Gravity))]
    [RequireComponent(typeof(BuildingConstruction))]
    public class Player : MonoBehaviour
    {
        private Input _input;
        private PhysicsMovement _movement;
        private PlayerRotation _cameraRotation;
        private Jumping _jumping;
        private GroundCheck _groundCheck;
        private Gravity _gravity;
        private BuildingConstruction _buildingConstruction;
        [SerializeField] private Transform _head;

        private void Awake()
        {
            _input = new Input();

            _movement = GetComponent<PhysicsMovement>();
            _cameraRotation = GetComponent<PlayerRotation>();
            _jumping = GetComponent<Jumping>();
            _groundCheck = GetComponent<GroundCheck>();
            _gravity = GetComponent<Gravity>();
            _buildingConstruction = GetComponent<BuildingConstruction>();
        }

        private void OnEnable()
        {
            _input.Controls.Player.Jump.performed += Jump;
            _input.Controls.Player.Build.performed += Build;
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Controls.Player.Jump.performed -= Jump;
            _input.Controls.Player.Build.performed -= Build;
            _input.Disable();
        }

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

        private void Build(InputAction.CallbackContext context) => _buildingConstruction.Build();
    }
}