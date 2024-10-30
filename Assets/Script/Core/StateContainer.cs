using System.Collections;
using UnityEngine;
using Tarahiro;

namespace gaw241020
{
    public class StateContainer : IStateContainer
    {

        IState m_CharacterState;

        public StateContainer(IState characterState)
        {
            m_CharacterState = characterState.RegisterStateContainer(this);
        }

        public IState GetCharacterState => m_CharacterState;

    }
}