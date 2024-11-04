using System.Collections;
using UnityEngine;
using Tarahiro;

namespace gaw241020
{
    public class StateContainer : IStateContainer
    {

        IState m_CharacterState;
        IState m_TalkState;
        IState m_WarpState;
        IState m_UnlockState;
        IState m_EndState;

        public StateContainer(IState characterState, IState talkState,IState warpState,IState unlockState,IState endState)
        {
            m_CharacterState = characterState.RegisterStateContainer(this);
            m_TalkState = talkState.RegisterStateContainer(this);
            m_WarpState = warpState.RegisterStateContainer(this);
            m_UnlockState = unlockState.RegisterStateContainer(this);
            m_EndState = endState.RegisterStateContainer(this);
        }

        public IState GetCharacterState => m_CharacterState;
        public IState GetTalkState => m_TalkState;
        public IState GetWarpState => m_WarpState;
        public IState GetUnlockState => m_UnlockState;
        public IState GetEndState => m_EndState;

    }
}