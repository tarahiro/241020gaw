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
            Log.DebugAssert(state != null);
            m_StateMachine.SetNextState(state);
        }
    }
}