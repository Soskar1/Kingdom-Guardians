using UnityEngine;

namespace KingdomGuardians.Core
{
    public sealed class Input
    {
        private Controls _controls;

        public Controls Controls => _controls;

        public Input() => _controls = new Controls();
        public void Enable() => _controls.Enable();
        public void Disable() => _controls.Disable();

        public Vector2 ReadMovement() => _controls.Player.Movement.ReadValue<Vector2>();
    }
}