using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gaw241020.Presenter;
using UnityEngine;

namespace gaw241020.View
{
    internal interface ICharacterMoverFactory
    {
        ICharacterMover CreateCharacterMover(CharacterPresenter.CharacterMoveState moveState);
    }
}
