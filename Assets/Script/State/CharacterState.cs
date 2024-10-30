using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using Zenject;

namespace gaw241020.State
{
    public class CharacterState : IState
    {
        [Inject]
        ICharacterPresenter m_CharacterPresenter;

        public CharacterState(ICharacterPresenter characterPresenter)
        {

        }

        public async UniTask Enter()
        {
            await m_CharacterPresenter.Enter();
        }

        IStateContainer m_StateContainer;

        public IState RegisterStateContainer(IStateContainer stateContainer)
        {
            m_StateContainer = stateContainer;
            m_CharacterPresenter.SetStateContainer(stateContainer);
            return this;
        }
    }
}
