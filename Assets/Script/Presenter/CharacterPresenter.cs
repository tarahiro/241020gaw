using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Zenject;
using gaw241020.State;
using gaw241020;
using Tarahiro;

namespace gaw241020.Presenter
{
    public class CharacterPresenter : ICharacterPresenter, ICharacterCollisionPresenter
    {
        [Inject]
        ICharacterModel m_CharacterModel;

        [Inject]
        ICharacterView characterView;

        [Inject]
        IStateChanger stateChanger;

        [Inject]
        IGridModel gridModel;

      //  [Inject]
        ICharacterInputView m_CharacterInputView;

        public CharacterPresenter(ICharacterModel characterModel, ICharacterView characterView, IGridModel gridModel, ICharacterInputView characterInputView, IStateChanger stateChanger)
        {
            m_CharacterModel = characterModel;
            characterModel.Moved.Subscribe(MoveCharacterView);

            m_CharacterInputView = characterInputView;
        }

        void MoveCharacterView(Vector2Int vector2Int)
        {
            characterView.Move(vector2Int);
        }

        bool m_IsLoop = true;

        public async UniTask Enter()
        {
            StateStart();
            while (m_IsLoop)
            {
                await StateMainLoop();
            }
            StateExit();
        }

        void StateStart()
        {
            Log.DebugLog("�L�����N�^�[����J�n����");
            m_IsLoop = true;
            CheckIsLocationTouched();
        }

        async UniTask StateMainLoop()
        {
            Log.DebugLog("�L�����N�^�[����[�v����");
            await UniTask.WaitUntil(() => WaitInput());
            await UniTask.WaitUntil(() => !characterView.isMoving);

            CheckIsLocationTouched();
        }

        IStateContainer m_StateContainer;

        public void SetStateContainer(IStateContainer stateContainer)
        {
            m_StateContainer = stateContainer;
        }


        void StateExit()
        {
            Log.DebugLog("�L�����N�^�[����I������");
            if (m_CharacterInputView.IsDecideGuideDisplayed)
            {
                m_CharacterInputView.EraseDecideGuide();
            }
        }
        bool WaitInput()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                TryWalk(Vector2Int.up);
                return true;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                TryWalk(Vector2Int.right);
                return true;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                TryWalk(Vector2Int.down);
                return true;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                TryWalk(Vector2Int.left);
                return true;
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                TryTalk();
                return true;
            }
            return false;
        }

        bool TryWalk(Vector2Int direction)
        {
            if(gridModel.IsWalkable(m_CharacterModel.CharacterPosition + direction))
            {
                m_CharacterModel.Walk(direction);
                return true;

            }
            else
            {
                return false;
            }

        }

        bool TryTalk()
        {
            if (m_CharacterModel.IsTouchingLocationExist)
            {
                //Talk�֑J��
                stateChanger.ChangeState(m_StateContainer.GetTalkState);
                EndLoop();
                return true;
            }
            return false;
        }

        void EndLoop()
        {
            m_IsLoop = false;
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


        public void EnterCharacterToLocation(GameObject townObject)
        {
            Debug.Log("�L�����N�^�[��Town�ɐG�ꂽ���Ƃ�Presenter�Ŏ擾");

            m_CharacterModel.EnterCharacterToLocation(townObject.name);
        }

        public void ExitCharacterFromLocation(GameObject townObject)
        {
            Debug.Log("�L�����N�^�[��Town���痣�ꂽ���Ƃ�Presenter�Ŏ擾");

            m_CharacterModel.ExitCharacterFromLocation(townObject.name);
        }
    }
}
