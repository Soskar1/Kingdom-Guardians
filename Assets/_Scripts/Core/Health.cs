using UnityEngine;
using System;

namespace KingdomGuardians.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        private int _currentHealth;

        private Action _healthReduced;
        private Action _healthIsGone;

        private void Start() => _currentHealth = _maxHealth;

        private void OnDisable()
        {
            _healthReduced = null;
            _healthIsGone = null;
        }

        public void Reduce(int health)
        {
            _currentHealth -= health;
            Debug.Log($"Current health: {_currentHealth}");
            _healthReduced?.Invoke();

            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                _healthIsGone?.Invoke();
            }
        }

        public void AddHealthReducedEvent(Action healthReducedEvent) => _healthReduced += healthReducedEvent;
        public void RemoveHealthReducedEvent(Action healthReducedEvent) => _healthReduced -= healthReducedEvent;
        public void AddHealthIsGoneEvent(Action healthIsGoneEvent) => _healthIsGone += healthIsGoneEvent;
        public void RemoveHealthIsGoneEvent(Action healthIsGoneEvent) => _healthIsGone -= healthIsGoneEvent;
    }
}