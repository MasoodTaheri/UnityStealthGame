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
        [SerializeField]
        public Istate CurrentState { get; private set; }

        public StartState StartState;
        public PatrolState PartolState;
        public ChaseState ChaseState;
        public NoiseAlertState NoiseAlertState;

        public event Action<Istate> StateChanged;

        public StateMachineController(Enemy enemy, PatrolingOnNodes patrolingOnNodes)
        {
            PartolState = new PatrolState(enemy, patrolingOnNodes);
            StartState = new StartState(enemy);
            ChaseState = new ChaseState(enemy);
            NoiseAlertState = new NoiseAlertState(enemy);

            //Debug.Log("StateMachineController created");
        }

        public void Initialize(Istate state)
        {
            //Debug.Log("StateMachineController Initialize");
            CurrentState = state;
            state.Enter();
            StateChanged?.Invoke(state);
        }

        public void TransitionTo(Istate nextState)
        {
            //Debug.Log("TransitionTo " + nextState.Name);
            CurrentState.Exit();
            CurrentState = nextState;
            nextState.Enter();


            StateChanged?.Invoke(nextState);
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