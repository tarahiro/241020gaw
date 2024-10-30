using System.Collections;
using UnityEngine;
using Zenject;
using Tarahiro;

namespace gaw241020.State
{
    public class StateChanger : IStateChanger
    {
        [Inject]
        IStateMachine m_StateMachine;


        public StateChanger(IStateMachine stateMachine)
        {

        }

        public void ChangeState(IState state)
        {
            m_StateMachine.SetNextState(state);
        }
    }
}