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

        public void ChangeState(IState state)
        {
            
            Log.DebugAssert(state != null);
            if (m_StateMachine.IsRegisteredNextState())
            {
                Log.DebugLog("次ステート登録済み");
            }
            else
            {
                m_StateMachine.SetNextState(state);
            }
        }

    }
}