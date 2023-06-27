using Assets.Scripts.EnemyCode;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.FSM
{
    [Serializable]
    public class StateMachineController
    {

        public StartState StartState;
        public PatrolState PartolState;
        public ChaseState ChaseState;
        public NoiseAlertState NoiseAlertState;
        [SerializeField] public Istate CurrentState { get; private set; }



        public StateMachineController(Enemy enemy, PatrolingOnNodes patrolingOnNodes)
        {
            PartolState = new PatrolState(enemy, patrolingOnNodes);
            StartState = new StartState(enemy);
            ChaseState = new ChaseState(enemy);
            NoiseAlertState = new NoiseAlertState(enemy);
        }

        public void Initialize(Istate state)
        {
            CurrentState = state;
            state.Enter();
        }

        public void TransitionTo(Istate nextState)
        {
            CurrentState.Exit();
            CurrentState = nextState;
            nextState.Enter();
        }

        public void Update()
        {
            if (CurrentState != null)
            {
                CurrentState.Update();
            }
        }
    }
}