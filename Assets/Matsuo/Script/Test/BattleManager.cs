using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State = StateMachine<TestM.BattleManager>.State;


namespace TestM
{

    public class BattleManager : MonoBehaviour
    {
        [SerializeField, Tooltip("")]
        BattleMode _currentBattleMode;

        StateMachine<BattleManager> _stateMachine;



        void Start()
        {
            StateCash();

        }

        void Update()
        {
            _stateMachine.Update();
        }

        #region StateMachine
        private void StateCash()
        {
            _stateMachine = new StateMachine<BattleManager>(this);

            _stateMachine.AddAnyTransition<SelectionModeState>((int)BattleMode.Selection);
            _stateMachine.AddAnyTransition<BattleModeState>((int)BattleMode.Battle);
            _stateMachine.AddAnyTransition<ResultModeState>((int)BattleMode.Result);

            _stateMachine.Start<SelectionModeState>();
        }

        void ChangeState(BattleMode nextState)
        {
            Debug.Log($"É^Å[ÉìïœçX {nextState}");
            _currentBattleMode = nextState;
            _stateMachine.StateChange((int)_currentBattleMode);
        }
        #endregion

        #region SelectionModeState
        private class SelectionModeState : State
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

        #region BattleModeState
        private class BattleModeState : State
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

        #region ResultModeState
        private class ResultModeState : State
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
