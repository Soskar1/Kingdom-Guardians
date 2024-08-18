using UnityEngine;

namespace KingdomGuardians.Core
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private Transform _head;
        [SerializeField] private float _xSensitivity;
        [SerializeField] private float _ySensitivity;

        [SerializeField] private float _yMin;
        [SerializeField] private float _yMax;

        private float _xRot = 0;
        private float _yRot = 0;

        private bool _canRotate = true;

        public bool CanRotate { set => _canRotate = value; }

        public void Rotate(Vector2 deltaMouse)
        {
            if (!_canRotate)
                return;

            Vector2 targetRotation = new Vector2(
                deltaMouse.x * _xSensitivity,
                deltaMouse.y * _ySensitivity
                );

            _yRot += targetRotation.x;
            _xRot -= targetRotation.y;
            _xRot = Mathf.Clamp(_xRot, _yMin, _yMax);
            _head.localRotation = Quaternion.Euler(_xRot, _yRot, 0.0f);
        }
    }
}