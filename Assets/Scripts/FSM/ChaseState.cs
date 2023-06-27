using Assets.Scripts.EnemyCode;
using UnityEngine;


namespace Assets.Scripts.FSM
{
    public class ChaseState : Istate
    {
        public string Name => _name;

        private Enemy _enemy;
        private float _distanceToLastKnownPosition;
        private float _minDistance = 2;
        private Vector3 _lastKnownPosition;
        private string _name;

        public ChaseState(Enemy enemy)
        {
            _enemy = enemy;
            _name = "chase";
        }

        public void Enter()
        {
            

        }

        public void Exit()
        {
            
        }

        public void Update()
        {

            if (_enemy.playerDetection())
            {
                _lastKnownPosition = _enemy.LastknownPlayerPosition;
            }

            _enemy.NavMeshAgent.destination = _lastKnownPosition;
            _distanceToLastKnownPosition = Vector3.Distance(_enemy.transform.position, _lastKnownPosition);
            if (_distanceToLastKnownPosition < _minDistance)
            {
                _enemy.StateController.TransitionTo(_enemy.StateController.PartolState);
            }
        }
    }
}