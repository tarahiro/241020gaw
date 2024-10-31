using System.Collections;
using UnityEngine;
using Zenject;

namespace gaw241020.Presenter
{
    public class MoveCommand : ICommand
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

        public MoveCommand(ICharacterModel characterModel, IGridModel gridModel, ICharacterView characterView,ICharacterInputView characterInputView, Vector2Int direction)
        {
            m_GridModel = gridModel;
            m_CharacterModel = characterModel;
            m_CharacterView = characterView;
            m_CharacterInputView = characterInputView;
            m_Direction = direction;
        }


        public void Execute()
        {
            TryWalk(m_Direction);
        }

        public void EndCommand()
        {
            CheckIsLocationTouched();
        }


        public bool IsEndState => false;

        public bool IsEndCommand => !m_CharacterView.isMoving;

        bool TryWalk(Vector2Int direction)
        {
            if (m_GridModel.IsWalkable(m_CharacterModel.CharacterPosition + direction))
            {
                m_CharacterModel.Walk(direction);
                return true;
            }
            else
            {
                return false;
            }

        }

        void CheckIsLocationTouched()
        {
            if (m_CharacterModel.IsTouchingLocationExist)
            {
                if (!m_CharacterInputView.IsDecideGuideDisplayed)
                {
                    m_CharacterInputView.ShowDecideGuide();
                }
            }
            else
            {
                if (m_CharacterInputView.IsDecideGuideDisplayed)
                {
                    m_CharacterInputView.EraseDecideGuide();
                }
            }

        }
    }
}