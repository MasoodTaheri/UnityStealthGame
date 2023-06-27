using Assets.Scripts.EnemyCode;
using UnityEngine;

namespace Assets.Scripts.FSM
{
    public class NoiseAlertState : Istate
    {
        public string Name => _name;

        private Enemy _enemy;
        private string _name;
        private float _distanceToNoisePosition;
        private float _minDistance = 2;

        public NoiseAlertState(Enemy enemy)
        {
            _enemy = enemy;
            _name = "noiseAlerted";
        }

        public void Enter()
        {
            _enemy.NavMeshAgent.destination = _enemy.AlertPosition;
        }

        public void Exit()
        {

        }

        public void Update()
        {
            if (_enemy.playerDetection())
            {
                _enemy.StateController.TransitionTo(_enemy.StateController.ChaseState);
            }
            _distanceToNoisePosition = Vector3.Distance(_enemy.transform.position, _enemy.AlertPosition);
            if (_distanceToNoisePosition < _minDistance)
            {
                _enemy.StateController.TransitionTo(_enemy.StateController.PartolState);
            }
        }
    }
}