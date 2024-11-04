using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gaw241020.Presenter;
using Tarahiro;

namespace gaw241020.View
{
    public class CharacterViewFactory : ICharacterViewFactory
    {
        public ICharacterView CreateCharacterView(CharacterPresenter.CharacterMoveState moveState)
        {
            switch (moveState)
            {
                case CharacterPresenter.CharacterMoveState.Human:
                    return new CharacterHumanView();

               default:
                    Log.DebugAssert(false);
                    return null;


            }
        }
    }
}
