using Assets.Scripts.EnemyCode;
using UnityEngine;

namespace Assets.Scripts.FSM
{
    public class PatrolState : Istate
    {
        private Enemy _enemy;
        private IPatrolOnNode _PatrolOnNodes;

        public PatrolState(Enemy enemy, IPatrolOnNode patrolOnNode)
        {
            _enemy = enemy;
            _PatrolOnNodes = patrolOnNode;
            _name = "PatrolState";
        }
        private string _name;
        public string Name => _name;

        public void Enter()
        {
            Debug.Log("PatrolState Enter");

            _PatrolOnNodes.Initialize();
        }

        public void Exit()
        {
            Debug.Log("PatrolState Exit");
        }

        public void Update()
        {
            //Debug.Log("PatrolState Update");
            _PatrolOnNodes.UpdatePatrol();
            if (_enemy.playerDetection())
            {
                _enemy.controller.TransitionTo(_enemy.controller.ChaseState);
            }
        }
    }
}