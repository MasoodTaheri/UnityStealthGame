using Assets.Scripts.FSM;
using System;
using UnityEngine;

namespace Assets.Scripts.EnemyCode
{
    public class GuardEnemy : Enemy
    {
        [SerializeField] private PatrolingOnNodes patrolingOnNodes;
        [SerializeField] private PathController _pathController;


        public void SetPathController(PathController pathController)
        {
            _pathController = pathController;
            patrolingOnNodes.pathController = _pathController;
        }
        private void Awake()
        {
            controller = new StateMachineController(this, patrolingOnNodes);
            patrolingOnNodes.navMeshAgent = navMeshAgent;


        }
        private void Start()
        {
            controller.Initialize(controller.StartState);
        }


        private void Update()
        {
            base.Update();
            controller.Update();

            Debug.DrawRay(transform.position, transform.forward);
        }


    }
}