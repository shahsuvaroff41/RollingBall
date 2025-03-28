using UnityEngine;
using UnityEngine.AI;

namespace MiniGame.Enemy
{
    public class EnemyChase : MonoBehaviour
    {
        public Transform target;
        private NavMeshAgent _agent;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
        }


        private void FixedUpdate()
        {
            if (target is not null) _agent.SetDestination(target.position);
        }
    }
}