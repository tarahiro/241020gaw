using System.Collections;
using UnityEngine;
using Zenject;
using gaw241020.State;
using Tarahiro;

namespace gaw241020.Presenter
{
    public class TalkCommand : ICommand
    {
        IStateChanger m_StateChanger;

        ICharacterModel m_CharacterModel;

        IState m_TalkState;

        bool m_IsEndState = false;

        public TalkCommand(IStateChanger stateChanger,ICharacterModel characterModel,  IState talkState)
        {
            m_StateChanger = stateChanger;
            m_CharacterModel = characterModel;
            m_TalkState = talkState;
        }

        public void Execute()
        {
            TryTalk();
        }

        void TryTalk()
        {
            if (m_CharacterModel.IsTouchingLocationExist)
            {
                Log.DebugLog(m_CharacterModel.TouchingLocationId);
                SoundManager.PlaySE("Enter");
                m_StateChanger.ChangeState(m_TalkState);
                m_IsEndState = true;
            }
        }

        public void EndCommand()
        {
            //何も書かないのはよくないが…
            //ここにステート終了処理的なのを入れるべきでは？
        }
        public bool IsCircluateCommand => false;

        public bool IsEndState => m_IsEndState;

        public bool IsEndCommand => true;
    }
}