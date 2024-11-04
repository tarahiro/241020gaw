using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gaw241020.Presenter;
using Tarahiro;
using UnityEngine;

namespace gaw241020.View
{
    public class CharacterMoverFactory : ICharacterMoverFactory
    {
        public ICharacterMover CreateCharacterMover(CharacterPresenter.CharacterMoveState moveState)
        {
            switch (moveState)
            {
                case CharacterPresenter.CharacterMoveState.Human:
                    return new CharacterMover();

               default:
                    Log.DebugAssert(false);
                    return null;


            }
        }
    }
}
