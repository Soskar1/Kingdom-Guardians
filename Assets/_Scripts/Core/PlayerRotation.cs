using UnityEngine;

namespace KingdomGuardians.Core
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private Transform _head;
        [SerializeField] private Transform _body;
        [SerializeField] private float _xSensitivity;
        [SerializeField] private float _ySensitivity;

        [SerializeField] private float _yMin;
        [SerializeField] private float _yMax;

        private float _xRot = 0;

        public void Rotate(Vector2 deltaMouse)
        {
            Vector2 targetRotation = new Vector2(
                deltaMouse.x * _xSensitivity,
                deltaMouse.y * _ySensitivity
                ) * Time.deltaTime;

            _body.transform.eulerAngles += new Vector3(0.0f, targetRotation.x, 0.0f);

            _xRot -= targetRotation.y;
            _xRot = Mathf.Clamp(_xRot, _yMin, _yMax);
            _head.transform.localRotation = Quaternion.Euler(_xRot, 0.0f, 0.0f);
        }
    }
}