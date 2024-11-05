using System.Collections;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Zenject;
using Tarahiro;
using gaw241020.State;


namespace gaw241020.Presenter
{

    public class UnlockPresenter : IUnlockPresenter
    {
        [Inject]
        IUnlockModel m_UnlockModel;

        [Inject]
        ICharacterModel m_CharacterModel;

        [Inject]
        IStateChanger m_StateChanger;

        IStateContainer m_StateContainer;

        public async UniTask Enter()
        {
            string unlockId = m_UnlockModel.GetUnlockContentId;

            switch (unlockId)
            {
                case "Ship":
                    m_CharacterModel.EnableCharacterShip();
                    m_CharacterModel.SetCharacterMoveState(CharacterPresenter.CharacterMoveState.Ship);
                    m_UnlockModel.ResetUnlockContentId();
                    break;

                default:
                    Log.DebugAssert(false);
                    break;
            }
            m_StateChanger.ChangeState(m_StateContainer.GetCharacterState);
        }


        public void SetStateContainer(IStateContainer stateContainer)
        {
            m_StateContainer = stateContainer;
        }
    }
}
