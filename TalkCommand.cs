using UnityEditor;
using UnityEngine;
using Zenject;
using gaw241020.State;

namespace gaw241020.Presenter
{
    public class TalkCommand : ICommand
    {
        [Inject]
        ICharacterModel m_CharacterModel;

        [Inject]
        IStateChanger m_StateChanger;

        IState m_TalkState;

        public TalkCommand(ICharacterModel characterModel, IStateChanger stateChanger, IState talkState)
        {
            m_CharacterModel = characterModel;
            m_StateChanger = stateChanger;
            m_TalkState = talkState;
        }

        public void Execute()
        {
            TryTalk();
        }

        public bool IsMoveCommand => false;

        bool TryTalk()
        {
            if (m_CharacterModel.IsTouchingLocationExist)
            {
                //Talkへ遷移
                m_StateChanger.ChangeState(m_TalkState);
               // EndLoop();
                return true;
            }
            return false;
        }
    }
}