using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using Zenject;
using Tarahiro;
using gaw241020;

namespace gaw241020.State
{
    public class EndState : IState
    {
        [Inject]
        IEndPresenter m_EndPresenter;

        public async UniTask Enter()
        {
            await m_EndPresenter.Enter();
        }

        IStateContainer m_StateContainer;

        public IState RegisterStateContainer(IStateContainer stateContainer)
        {
            m_StateContainer = stateContainer;
            return this;
        }
    }
}
