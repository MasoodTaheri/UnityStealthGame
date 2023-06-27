
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.EnemyCode
{
    public class PatrolingOnNodes : MonoBehaviour, IPatrolOnNode
    {
        public PathController pathController;
        public float DistanceToNode;
        public float MinDistance;
        public float Speed;

        [SerializeField] private GameObject _agent;
        [HideInInspector] public NavMeshAgent navMeshAgent;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector3 direction = _agent.transform.TransformDirection(Vector3.forward) * 3;
            Gizmos.DrawRay(_agent.transform.position, direction);
        }

        public void Initialize()
        {
            navMeshAgent.destination = pathController.GetCurrentNodePosition();
        }


        public void UpdatePatrol()
        {
            DistanceToNode = Vector3.Distance(_agent.transform.position, pathController.GetCurrentNodePosition());
            if (DistanceToNode < MinDistance)
            {
                pathController.NextNode();
                navMeshAgent.destination = pathController.GetCurrentNodePosition();
            }
        }
    }
}