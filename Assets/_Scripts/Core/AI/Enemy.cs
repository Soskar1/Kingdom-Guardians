using UnityEngine;
using UnityEngine.AI;

namespace KingdomGuardians.Core.AI
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(ActionsOnPursuit))]
    [RequireComponent(typeof(AttackAction))]
    [RequireComponent(typeof(Ragdoll))]
    public class Enemy : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private ActionsOnPursuit _onPursuit;
        private AttackAction _attackAction;
        private Ragdoll _ragdoll;

        public bool IsRagdoll { get; private set; }

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _attackAction = GetComponent<AttackAction>();
            _onPursuit = GetComponent<ActionsOnPursuit>();
            _ragdoll = GetComponent<Ragdoll>();
        }

        public void TurnToRagdoll()
        {
            if (IsRagdoll)
                return;

            _agent.enabled = false;
            _onPursuit.enabled = false;
            _attackAction.enabled = false;
            _ragdoll.Enable();

            IsRagdoll = true;
        }
    }
}