using Assets.Scripts.EnemyCode;
using UnityEngine;


namespace Assets.Scripts.FSM
{
    public class ChaseState : Istate
    {
        private Enemy _enemy;
        private float DistanceToLastKnownPosition;
        private float minDistance = 2;
        private Vector3 LastKnownPosition;
        private string _name;
        public string Name => _name;

        public ChaseState(Enemy enemy)
        {
            _enemy = enemy;
            _name = "chase";
        }

        public void Enter()
        {
            Debug.Log("ChaseState Enter");

        }

        public void Exit()
        {
            Debug.Log("ChaseState Exit");
        }

        public void Update()
        {
            //Debug.Log("ChaseState Update");
            if (_enemy.playerDetection())
            {
                LastKnownPosition = _enemy.LastknownPlayerPosition;
            }

            _enemy.navMeshAgent.destination = LastKnownPosition;
            DistanceToLastKnownPosition = Vector3.Distance(_enemy.transform.position, LastKnownPosition);
            if (DistanceToLastKnownPosition < minDistance)
            {
                _enemy.controller.TransitionTo(_enemy.controller.PartolState);
            }
        }
    }
}