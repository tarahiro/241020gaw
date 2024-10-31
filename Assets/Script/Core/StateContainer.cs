using System.Collections;
using UnityEngine;
using Tarahiro;

namespace gaw241020
{
    public class StateContainer : IStateContainer
    {

        IState m_CharacterState;
        IState m_TalkState;

        public StateContainer(IState characterState, IState talkState)
        {
            m_CharacterState = characterState.RegisterStateContainer(this);
            m_TalkState = talkState.RegisterStateContainer(this);
        }

        public IState GetCharacterState => m_CharacterState;
        public IState GetTalkState => m_TalkState;

    }
}