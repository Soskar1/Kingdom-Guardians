using UnityEngine;

namespace KingdomGuardians.Core
{
    public sealed class Input
    {
        private Controls _controls;

        public Controls Controls => _controls;

        public Vector2 Movement => _controls.Player.Movement.ReadValue<Vector2>();
        public Vector2 DeltaMouse => _controls.Player.DeltaMouse.ReadValue<Vector2>();

        public Input() => _controls = new Controls();
        public void Enable() => _controls.Enable();
        public void Disable() => _controls.Disable();
    }
}