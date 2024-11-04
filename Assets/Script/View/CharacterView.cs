using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using LitMotion;
using LitMotion.Extensions;
using gaw241020;
using gaw241020.Presenter;
using Tarahiro;
using System.Linq;
using Zenject;

namespace gaw241020.View {
    public class CharacterView : ICharacterView
    {
        //Memo ‚±‚ÌƒNƒ‰ƒX‚àMonoBehaviour‚É‚µ‚Ä‚à‚¢‚¢‹C‚à‚·‚é

        const float c_WalkSecondsPerTile = .26f;

        string m_LatestDirectionString;

        ICharacterMover m_CharacterMover;

        [Inject]
        ICharacterMoverContainer m_CharacterMoverContainer;

        //DirectionŽü‚è‚ÍUtil‚É‚Ü‚Æ‚ß‚é‚©‚à



        public CharacterView()
        {

        }

        public async UniTask Move(Vector2Int vector2Int) => await m_CharacterMover.Move(vector2Int);
        public void StopMoveBehavior() => m_CharacterMover.StopMoveBehavior();
        public bool isMoving => m_CharacterMover.IsMoving;


        public void SetMoveState(CharacterPresenter.CharacterMoveState moveState)
        {
            m_CharacterMover = m_CharacterMoverContainer.GetCharacterMover(moveState);
        }

    }
}
