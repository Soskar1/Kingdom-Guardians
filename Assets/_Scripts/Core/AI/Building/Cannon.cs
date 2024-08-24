using UnityEngine;

namespace KingdomGuardians.Core.AI.Building
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private CannonBall _cannonBall;
        [SerializeField] private Transform _shotPoint;
        [SerializeField] private float _delay;
        [SerializeField] private float _power;
        [SerializeField] private float _verticalPower;

        private float _timer;

        private void Start() => _timer = _delay;

        private void Update()
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }
            else
            {
                Shoot();
                _timer = _delay;
            }
        }

        public void Shoot()
        {
            CannonBall cannonBallInstance = Instantiate(_cannonBall, _shotPoint.position, Quaternion.identity);
            cannonBallInstance.Push((transform.forward + Vector3.up * _verticalPower) * _power);
        }
    }
}