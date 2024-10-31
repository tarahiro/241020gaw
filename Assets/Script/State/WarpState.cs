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
    public class WarpState : IState
    {
        [Inject]
        IWarpPresenter m_WarpPresenter;

        public async UniTask Enter()
        {
            await m_WarpPresenter.Enter();
        }

        IStateContainer m_StateContainer;

        public IState RegisterStateContainer(IStateContainer stateContainer)
        {
            m_StateContainer = stateContainer;
            m_WarpPresenter.SetStateContainer(m_StateContainer);
            return this;
        }
    }
}
