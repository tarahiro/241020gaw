using System.Collections;
using UnityEngine;
using gaw241020;
using Zenject;
using Tarahiro;

namespace gaw241020.State
{
    // 循環コンストラクトを防ぐため、Factoryを用意。Stateを使う段階でこれを呼ぶ
    public class StateContainerFactory : IStateContainerFactory
    {
        [Inject]
        CharacterState m_CharacterState;

        [Inject]
        TalkState m_TalkState;

        IStateContainer m_StateContainer;

        public IStateContainer CreateStateContainer()
        {
            Log.DebugAssert(m_StateContainer == null);

           return new StateContainer(m_CharacterState,m_TalkState);
        }


    }
}