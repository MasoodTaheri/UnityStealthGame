using Assets.Scripts.FSM;
using System;
using UnityEngine;

namespace Assets.Scripts.EnemyCode
{
    public class GuardEnemy : Enemy
    {
        [SerializeField] private PatrolingOnNodes _patrolingOnNodes;

         private PathController _pathController;


        public void SetPathController(PathController pathController)
        {
            _pathController = pathController;
            _patrolingOnNodes.pathController = _pathController;
        }
        private void Awake()
        {
            StateController = new StateMachineController(this, _patrolingOnNodes);
            _patrolingOnNodes.navMeshAgent = NavMeshAgent;


        }
        private void Start()
        {
            StateController.Initialize(StateController.StartState);
        }


        private void Update()
        {
            base.Update();
            StateController.Update();

            Debug.DrawRay(transform.position, transform.forward);
        }


    }
}