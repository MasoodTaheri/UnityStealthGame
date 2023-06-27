using Assets.Scripts.EnemyCode;
using UnityEngine;

namespace Assets.Scripts.FSM
{
    public class StartState : Istate
    {
        private Enemy _enemy;

        public StartState(Enemy enemy)
        {
            _enemy = enemy;
            _name = "StartState";
        }
        private string _name;
        public string Name => _name;
        public void Enter()
        {

            Debug.Log("StartState Enter");
            _enemy.controller.TransitionTo(_enemy.controller.PartolState);

        }

        public void Exit()
        {
            Debug.Log("StartState Exit");
        }

        public void Update()
        {
            //Debug.Log("StartState Update");
            _enemy.playerDetection();

        }
    }
}