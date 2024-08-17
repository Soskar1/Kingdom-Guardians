using UnityEngine;
using UnityEngine.AI;

namespace KingdomGuardians.Core.AI
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Navigation : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        private NavMeshAgent _agent;

        public Vector3 CurrentDestination { get; private set; }

        private void Awake() => _agent = GetComponent<NavMeshAgent>();

        private void Start()
        {
            Physics.Raycast(transform.position, _target.position - transform.position, out RaycastHit hitInfo, Mathf.Infinity);

            if (hitInfo.point == null)
            {
                Debug.LogWarning("No collider");
                return;
            }

            CurrentDestination = new Vector3(hitInfo.point.x, transform.position.y, hitInfo.point.z);
            _agent.destination = CurrentDestination;
        }
    }
}