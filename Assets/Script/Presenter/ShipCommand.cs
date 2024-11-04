using System.Collections;
using UnityEngine;
using Zenject;

namespace gaw241020.Presenter
{
    public class ShipCommand : ICommand
    {

        [Inject]
        ICharacterModel m_CharacterModel;

        [Inject]
        IGridModel m_GridModel;

        [Inject]
        ICharacterView m_CharacterView;

        [Inject]
        ICharacterInputView m_CharacterInputView;

        Vector2Int m_Direction;

        public ShipCommand(ICharacterModel characterModel, IGridModel gridModel, ICharacterView characterView,ICharacterInputView characterInputView, Vector2Int direction)
        {
            m_GridModel = gridModel;
            m_CharacterModel = characterModel;
            m_CharacterView = characterView;
            m_CharacterInputView = characterInputView;
            m_Direction = direction;
        }


        public void Execute()
        {
            TryMove(m_Direction);
        }

        public void EndCommand()
        {
            m_CharacterView.StopMoveBehavior();
        }

        public bool IsCircluateCommand => true;

        public bool IsEndState => false;

        public bool IsEndCommand => !m_CharacterView.isMoving;

        bool TryMove(Vector2Int direction)
        {

            if (m_GridModel.IsWalkable(m_CharacterModel.CharacterPosition + direction))
            {
                m_CharacterModel.SetCharacterMoveState(CharacterPresenter.CharacterMoveState.Human);
                m_CharacterModel.Move(direction);
                return true;
            }
            else if
                (m_GridModel.IsShipable(m_CharacterModel.CharacterPosition + direction))
            {
                m_CharacterModel.Move(direction);
                return true;
            }
                return false;

        }

    }
}