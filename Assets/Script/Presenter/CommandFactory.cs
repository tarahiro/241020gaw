using System.Collections;
using UnityEngine;
using Zenject;
using Tarahiro;
using gaw241020.State;

namespace gaw241020.Presenter
{

    public class CommandFactory : ICommandFactory
    {
        [Inject]
        ICharacterModel m_CharacterModel;

        [Inject]
        IGridModel m_GridModel;

        [Inject]
        ICharacterView m_CharacterView;

        [Inject]
        ICharacterInputView m_CharacterInputView;

        [Inject]
        IStateChanger m_StateChanger;

        public ICommand CreateWalkCommand(Vector2Int direction)
        {
            return new WalkCommand(m_CharacterModel, m_GridModel, m_CharacterView, m_CharacterInputView, direction);
        }
        public ICommand CreateShipCommand(Vector2Int direction)
        {
            return new ShipCommand(m_CharacterModel, m_GridModel, m_CharacterView, m_CharacterInputView, direction);
        }

        public ICommand CreateTalkCommand(IState talkState)
        {
            return new TalkCommand(m_StateChanger,m_CharacterModel, talkState);

        }
    }
}