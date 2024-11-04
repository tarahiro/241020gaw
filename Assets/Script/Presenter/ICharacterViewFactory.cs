using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaw241020.Presenter
{
    public interface ICharacterViewFactory
    {
        ICharacterView CreateCharacterView(CharacterPresenter.CharacterMoveState moveState);
    }
}
