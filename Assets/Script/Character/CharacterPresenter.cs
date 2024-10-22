using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using gaw241020;
using UniRx;
using Zenject;

namespace gaw241020.Character {
    public class CharacterPresenter : ICharacterPresenter
    {
        [Inject]
        ICharacterModel characterModel;
        [Inject]
        ICharacterView characterView;

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
            }
        }

        bool WaitInput()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                characterModel.Walk(Vector2Int.up);
                return true;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                characterModel.Walk(Vector2Int.right);
                return true;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                characterModel.Walk(Vector2Int.down);
                return true;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                characterModel.Walk(Vector2Int.left);
                return true;
            }
            return false;
        }
    }
}
