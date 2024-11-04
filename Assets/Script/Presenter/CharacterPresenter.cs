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
        ICommandFactory m_CommandFactory;

        //  [Inject]
        ICharacterInputView m_CharacterInputView;

        [Inject]
        ICharacterViewContainer m_CharacterViewContainer;

        ICharacterView m_CharacterView;

        ICommand nextCommand;
        ICommand currentCommand;

        public enum CharacterMoveState
        {
            Human,
            Ship
        }

        public CharacterPresenter(ICharacterModel characterModel, ICharacterView characterView, ICharacterInputView characterInputView,ICommandFactory commandFactory, ICharacterViewContainer characterViewContainer)
        {
            m_CharacterModel = characterModel;
            m_CharacterInputView = characterInputView;
            m_CharacterViewContainer = characterViewContainer;

            //fake
            m_CharacterModel.EnableCharacterShip();

            InitializeCharacterMoveState(CharacterMoveState.Human);
            m_CharacterModel.EnteredInLocation.Subscribe(m_CharacterInputView.ShowDecideGuide);
            m_CharacterModel.ExitedFromLocation.Subscribe(m_CharacterInputView.EraseDecideGuide);
        }

        void InitializeCharacterMoveState(CharacterMoveState moveState)
        {
            m_CharacterView = m_CharacterViewContainer.GetCharacterView(moveState);
            InitializeCharacterModel(moveState);
        }

        void InitializeCharacterModel(CharacterMoveState moveState)
        {
            m_CharacterModel.SetCharacterMoveState(moveState);
            m_CharacterModel.Moved.Subscribe(MoveCharacterView);
        }

        

        void MoveCharacterView(Vector2Int vector2Int)
        {
            m_CharacterView.Move(vector2Int);
        }

        bool m_IsLoop = true;

        public async UniTask Enter()
        {
            StateStart();
            while (m_IsLoop)
            {
                await StateMainLoop();
            }
            Log.DebugLog("���[�v�I��");
            StateExit();
        }

        void StateStart()
        {
            Log.DebugLog("�L�����N�^�[����J�n����");
            m_IsLoop = true;
            // CheckIsLocationTouched(); Model���Ɏ�������ׂ�
        }

        async UniTask StateMainLoop()
        {
            //�L���ȓ��͂�҂��A���̃R�}���h��o�^����
            await UniTask.WaitUntil(() => TryGetNextCommand());

            CommandExecute:

            //���̃R�}���h�����s����
            currentCommand = nextCommand;
            nextCommand = null;
            currentCommand.Execute();

            //�R�}���h�̎��s���I���܂ő҂�
            await UniTask.WaitUntil(() => currentCommand.IsEndCommand);

            //���������Ŏ��������Ȃ�AEndCommand���Ă΂��ɌJ��Ԃ�
            if (currentCommand.IsCircluateCommand)
            {
                if (TryGetNextCommand())
                {
                    if (nextCommand.IsCircluateCommand)
                    {
                        goto CommandExecute;
                    }
                }
            }

            //�R�}���h���s��̏������s���@�R�}���h���ɍw�ǂ�������
            currentCommand.EndCommand();

            if (currentCommand.IsEndState)
            {
                EndLoop();
            }
            currentCommand = null;

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
                m_CharacterInputView.EraseDecideGuide(m_CharacterModel.TouchingLocationId);
            }
        }

        bool TryGetNextCommand()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                nextCommand = m_CommandFactory.CreateMoveCommand(Vector2Int.up);
                return true;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                nextCommand = m_CommandFactory.CreateMoveCommand(Vector2Int.right);
                return true;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                nextCommand = m_CommandFactory.CreateMoveCommand(Vector2Int.down);
                return true;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                nextCommand = m_CommandFactory.CreateMoveCommand(Vector2Int.left);
                return true;
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                nextCommand = m_CommandFactory.CreateTalkCommand(m_StateContainer.GetTalkState);
                return true;
            }
            nextCommand = null;
            return false;
        }

        void EndLoop()
        {
            Log.DebugLog("���[�v�I���ݒ�");
            m_IsLoop = false;
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
