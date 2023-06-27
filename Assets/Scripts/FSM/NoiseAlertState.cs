using Assets.Scripts.EnemyCode;
using UnityEngine;

namespace Assets.Scripts.FSM
{
    public class NoiseAlertState : Istate
    {
        private Enemy _enemy;
        private string _name;

        public float DistanceToNoisePosition;
        public float minDistance = 2;
        public string Name => _name;

        public NoiseAlertState(Enemy enemy)
        {
            _enemy = enemy;
            _name = "noiseAlerted";
        }

        public void Enter()
        {

            _enemy.navMeshAgent.destination = _enemy.AlertPosition;
        }

        public void Exit()
        {

        }

        public void Update()
        {
            if (_enemy.playerDetection())
            {
                _enemy.controller.TransitionTo(_enemy.controller.ChaseState);
            }
            DistanceToNoisePosition = Vector3.Distance(_enemy.transform.position, _enemy.AlertPosition);
            if (DistanceToNoisePosition < minDistance)
            {
                _enemy.controller.TransitionTo(_enemy.controller.PartolState);
            }
        }
    }
}