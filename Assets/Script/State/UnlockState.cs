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
    public class UnlockState : IState
    {
        [Inject]
        IUnlockPresenter m_UnlockPresenter;

        public async UniTask Enter()
        {
            await m_UnlockPresenter.Enter();
        }

        IStateContainer m_StateContainer;

        public IState RegisterStateContainer(IStateContainer stateContainer)
        {
            m_StateContainer = stateContainer;
            m_UnlockPresenter.SetStateContainer(m_StateContainer);
            return this;
        }
    }
}
