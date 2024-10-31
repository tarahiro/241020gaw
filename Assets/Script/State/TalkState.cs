using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using Zenject;
using gaw241020;

namespace gaw241020.State
{
    public class TalkState : IState
    {
        [Inject]
        ITalkPresenter m_TalkPresenter;


        public async UniTask Enter()
        {
            await m_TalkPresenter.Enter();
        }

        IStateContainer m_StateContainer;

        public IState RegisterStateContainer(IStateContainer stateContainer)
        {
            m_StateContainer = stateContainer;
            m_TalkPresenter.SetStateContainer(m_StateContainer);
            return this;
        }
    }
}
