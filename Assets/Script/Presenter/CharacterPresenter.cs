using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using gaw241020;
using UniRx;
using Zenject;

namespace gaw241020.Presenter {
    public class CharacterPresenter : ICharacterPresenter
    {
        [Inject]
        ICharacterModel characterModel;
        [Inject]
        ICharacterView characterView;
        [Inject]
        IGridModel gridModel;

        public CharacterPresenter(ICharacterModel characterModel, ICharacterView characterView)
        {
            characterModel.Moved.Subscribe(MoveCharacterView);
        }

        void MoveCharacterView(Vector2Int vector2Int)
        {
            characterView.Move(vector2Int);
        }



        public async UniTask Enter()
        {
            Debug.Log("ƒLƒƒƒ‰ˆÚ“®ŠJŽn");
            while (true)
            {
                await UniTask.WaitUntil(() => WaitInput());
                await UniTask.WaitUntil(() => !characterView.isMoving);
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
            return false;
        }

        bool TryWalk(Vector2Int direction)
        {
            if(gridModel.IsWalkable(characterModel.CharacterPosition + direction))
            {
                characterModel.Walk(direction);
                return true;

            }
            else
            {
                return false;
            }

        }
    }
}
