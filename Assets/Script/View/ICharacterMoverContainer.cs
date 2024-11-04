﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gaw241020.Presenter;

namespace gaw241020.View
{
    public interface ICharacterMoverContainer
    {
        ICharacterMover GetCharacterMover(CharacterPresenter.CharacterMoveState moveState);
    }
}
