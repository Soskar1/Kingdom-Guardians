using UnityEngine;
using System;

namespace KingdomGuardians.Core.AI
{
    [RequireComponent(typeof(Navigation))]
    public class ActionsOnPursuit : MonoBehaviour
    {
        private Navigation _navigation;
        [SerializeField] private float _minDistanceToTarget;

        private Action _pursuitAction;

        private void OnDisable() => _pursuitAction = null;

        private void Awake() => _navigation = GetComponent<Navigation>();

        private void Update()
        {
            float distanceToTarget = Vector3.Distance(transform.position, _navigation.CurrentDestination);

            if (distanceToTarget <= _minDistanceToTarget)
                _pursuitAction?.Invoke();
        }

        public void AddPursuitAction(Action pursuitAction) => _pursuitAction += pursuitAction;
        public void RemovePursuitAction(Action pursuitAction) => _pursuitAction -= pursuitAction;
    }
}