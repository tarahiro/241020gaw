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
        ICharacterView m_CharacterView;

        [Inject]
        IStateChanger m_StateChanger;

        [Inject]
        IGridModel gridModel;

        [Inject]
        ICommandFactory m_CommandFactory;

        //  [Inject]
        ICharacterInputView m_CharacterInputView;

        ICommand nextCommand;

        public CharacterPresenter(ICharacterModel characterModel, ICharacterView characterView, IGridModel gridModel, ICharacterInputView characterInputView, IStateChanger stateChanger,ICommandFactory commandFactory)
        {
            m_CharacterModel = characterModel;
            characterModel.Moved.Subscribe(MoveCharacterView);

            m_CharacterInputView = characterInputView;
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
            StateExit();
        }

        void StateStart()
        {
            Log.DebugLog("キャラクター操作開始処理");
            m_IsLoop = true;
            // CheckIsLocationTouched(); Model側に持たせるべき
        }

        async UniTask StateMainLoop()
        {
            //有効な入力を待ち、次のコマンドを登録する
            await UniTask.WaitUntil(() => TryGetNextCommand());

            //次のコマンドを実行する
            nextCommand.Execute();

            //コマンドの実行（※ここでは歩き）が終わるまで待つ　コマンド側に購読させられる
            await UniTask.WaitUntil(() => nextCommand.IsEndCommand);

            //コマンド実行後の処理を行う　コマンド側に購読させられる
            nextCommand.EndCommand();

            if (nextCommand.IsEndState)
            {
                EndLoop();
            }
            nextCommand = null;


        }

        IStateContainer m_StateContainer;

        public void SetStateContainer(IStateContainer stateContainer)
        {
            m_StateContainer = stateContainer;
        }


        void StateExit()
        {
            Log.DebugLog("キャラクター操作終了処理");
            if (m_CharacterInputView.IsDecideGuideDisplayed)
            {
                m_CharacterInputView.EraseDecideGuide();
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
            m_IsLoop = false;
        }

        public void EnterCharacterToLocation(GameObject townObject)
        {
            Debug.Log("キャラクターがTownに触れたことをPresenterで取得");

            m_CharacterModel.EnterCharacterToLocation(townObject.name);
        }

        public void ExitCharacterFromLocation(GameObject townObject)
        {
            Debug.Log("キャラクターがTownから離れたことをPresenterで取得");

            m_CharacterModel.ExitCharacterFromLocation(townObject.name);
        }
    }
}
