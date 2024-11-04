using System.Collections;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Zenject;
using Tarahiro;

namespace gaw241020
{
    public class StateMachine : IStateMachine
    {

        IState m_currentState;
        IState m_NextState;

        public StateMachine()
        {
            
        }

        public void SetNextState(IState state)
        {
            m_NextState = state;
        }

        public async UniTask Enter()
        {
            while (true)
            {
                Log.DebugAssert(m_NextState != null);

                m_currentState = m_NextState;
                m_NextState = null;
                await m_currentState.Enter();
            }

        }
        public bool IsRegisteredNextState()
        {
            return m_NextState != null;
        }
    }
}