using Assets.Scripts.EnemyCode;
using UnityEngine;

namespace Assets.Scripts.FSM
{
    public class StartState : Istate
    {
        public string Name => _name;
        private Enemy _enemy;
        private string _name;

        public StartState(Enemy enemy)
        {
            _enemy = enemy;
            _name = "StartState";
        }
        public void Enter()
        {
            _enemy.StateController.TransitionTo(_enemy.StateController.PartolState);
        }

        public void Exit()
        {

        }

        public void Update()
        {
            _enemy.playerDetection();
        }
    }
}