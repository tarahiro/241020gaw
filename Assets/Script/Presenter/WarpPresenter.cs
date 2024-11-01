using System.Collections;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Zenject;
using Tarahiro;
using gaw241020.State;

namespace gaw241020.Presenter { 
    public class WarpPresenter : IWarpPresenter
    {
        [Inject]
        IWarpModel m_WarpModel;

        [Inject]
        ICharacterModel m_CharacterModel;

        [Inject]
        ICharacterView m_CharacterView;

        [Inject]
        IStateChanger m_StateChanger;

        IStateContainer m_StateContainer;

        public async UniTask Enter()
        {
            Vector2Int destination = m_WarpModel.GetWarpDestination();

            Log.DebugLog("Fake: キャラクターをワープ位置まで動かす");
            m_CharacterModel.FakeWarp(destination);

            await UniTask.WaitUntil(() => !m_CharacterView.isMoving);

            m_CharacterView.StopMoveBehavior();
            m_StateChanger.ChangeState(m_StateContainer.GetCharacterState);
        }


        public void SetStateContainer(IStateContainer stateContainer)
        {
            m_StateContainer = stateContainer;
        }

    }
}