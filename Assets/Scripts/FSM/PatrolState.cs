using Assets.Scripts.EnemyCode;
using UnityEngine;

namespace Assets.Scripts.FSM
{
    public class PatrolState : Istate
    {
        public string Name => _name;

        private Enemy _enemy;
        private IPatrolOnNode _patrolOnNodes;
        private string _name;

        public PatrolState(Enemy enemy, IPatrolOnNode patrolOnNode)
        {
            _enemy = enemy;
            _patrolOnNodes = patrolOnNode;
            _name = "PatrolState";
        }

        public void Enter()
        {
            _patrolOnNodes.Initialize();
        }

        public void Exit()
        {

        }

        public void Update()
        {
            _patrolOnNodes.UpdatePatrol();
            if (_enemy.playerDetection())
            {
                _enemy.StateController.TransitionTo(_enemy.StateController.ChaseState);
            }
        }
    }
}