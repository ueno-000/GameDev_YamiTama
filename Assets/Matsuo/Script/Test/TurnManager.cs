using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State = StateMachine<TestM.TurnManager>.State;
using UnityEngine.Playables;


namespace TestM
{
    public class TurnManager : MonoBehaviour
    {
        StateMachine<TurnManager> _stateMachine;

        [SerializeField, Tooltip("")]
        TurnState _currentTurn;


        void Start ()
        {
            StateCash();

        }

        void Update () 
        {
            _stateMachine.Update();
        }

        #region StateMachine
        private void StateCash()
        {
            _stateMachine = new StateMachine<TurnManager>(this);

            _stateMachine.AddAnyTransition<PlayerTurnState>((int)TurnState.PlayerTurn);
            _stateMachine.AddAnyTransition<EnemyTurnState>((int)TurnState.EnemyTurn);

            _stateMachine.Start<PlayerTurnState>();
        }

        void ChangeState(TurnState nextState)
        {
            Debug.Log($"É^Å[ÉìïœçX {nextState}");
            _currentTurn = nextState;
            _stateMachine.StateChange((int)_currentTurn);
        }
        #endregion

        #region PlayerTurnState
        private class PlayerTurnState : State
        {
            protected override void OnEnter(State prevState)
            {

            }

            protected override void OnUpdate()
            {

            }

            protected override void OnExit(State nextState)
            {

            }
        }
        #endregion

        #region EnemyTurnState
        private class EnemyTurnState : State
        {
            protected override void OnEnter(State prevState)
            {

            }

            protected override void OnUpdate()
            {

            }

            protected override void OnExit(State nextState)
            {

            }
        }
        #endregion

    }
}