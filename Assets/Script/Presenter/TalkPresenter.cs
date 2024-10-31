using System.Collections;
using UnityEngine;
using gaw241020;
using gaw241020.State;
using Zenject;
using Tarahiro;
using Cysharp.Threading.Tasks;

namespace gaw241020.Presenter
{
    public class TalkPresenter : ITalkPresenter
    {
        [Inject]
        ICharacterModel m_CharacterModel;

        [Inject]
        ILocationModel m_LocationModel;

        [Inject]
        ITalkView m_TalkView;

        [Inject]
        IStateChanger m_StateChanger;

        IStateContainer m_StateContainer;
        
        public async UniTask Enter()
        {
            await m_TalkView.DisplayTalk(
                m_LocationModel.GetLocationDescription(m_CharacterModel.TouchingLocationId)
                );

            Log.DebugAssert(m_StateChanger != null);
            Log.DebugAssert(m_StateContainer != null);

            m_StateChanger.ChangeState(m_StateContainer.GetCharacterState);

        }

        public void SetStateContainer(IStateContainer stateContainer)
        {
            m_StateContainer = stateContainer;
        }

    }
}