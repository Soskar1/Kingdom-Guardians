using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace KingdomGuardians.Core.AI
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(ActionsOnPursuit))]
    public class AttackAction : MonoBehaviour
    {
        private ActionsOnPursuit _actionsOnPursuit;
        private NavMeshAgent _agent;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private int _damage;
        [SerializeField] private float _attackDelay;
        private float _attackDelayTimer;
        private bool _canAttack = true;

        private void Awake()
        {
            _actionsOnPursuit = GetComponent<ActionsOnPursuit>();
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Start() => _actionsOnPursuit.AddPursuitAction(Attack);

        private void Update()
        {
            if (_canAttack)
                return;

            if (_attackDelayTimer > 0)
            {
                _attackDelayTimer -= Time.deltaTime;
            }
            else
            {
                _canAttack = true;
                _attackDelayTimer = _attackDelay;
            }
        }

        private void Attack()
        {
            if (!_canAttack)
                return;

            _agent.isStopped = true;

            Health entityHealth = Physics.OverlapSphere(_attackPoint.position, 0.1f)
                .Select(collider => collider.GetComponent<Health>())
                .Where(health => health != null)
                .ToArray()
                .FirstOrDefault();

            if (entityHealth != null)
                entityHealth.Reduce(_damage);

            _canAttack = false;
        }
    }
}
