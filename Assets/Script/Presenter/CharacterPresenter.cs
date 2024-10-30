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

        public CharacterPresenter(ICharacterModel characterModel, ICharacterView characterView, IStateChanger stateChanger)
        {
            m_CharacterModel = characterModel;
            characterModel.Moved.Subscribe(MoveCharacterView);
        }

        void MoveCharacterView(Vector2Int vector2Int)
        {
            characterView.Move(vector2Int);
        }

        public async UniTask Enter()
        {
            Log.DebugLog("キャラ移動開始");
            while (true)
            {
                await UniTask.WaitUntil(() => WaitInput());
                await UniTask.WaitUntil(() => !characterView.isMoving);
                if (m_CharacterModel.IsTouchingLocationExist)
                {
                    Log.DebugLog("Talk");
//                    stateChanger.ChangeStateToTalk();
                }
            }
        }

        IStateContainer m_StateContainer;

        public void SetStateContainer(IStateContainer stateContainer)
        {
            m_StateContainer = stateContainer;
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
