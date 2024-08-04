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

        public void Rotate(Vector2 deltaMouse)
        {
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