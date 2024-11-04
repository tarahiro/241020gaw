using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using gaw241020.Presenter;

namespace gaw241020.View
{
    public class CharacterMoverContainer : ICharacterMoverContainer
    {
        [Inject]
        ICharacterMoverFactory m_CharacterMoverFactory;

        ICharacterMover[] characterMover = new ICharacterMover[Enum.GetNames(typeof(CharacterPresenter.CharacterMoveState)).Length];


        public ICharacterMover GetCharacterMover(CharacterPresenter.CharacterMoveState moveState)

        {
            if (characterMover[(int)moveState] == null)
            {
                characterMover[(int)moveState] = m_CharacterMoverFactory.CreateCharacterMover(moveState);
            }
            return characterMover[(int)moveState];
        }
    }
}
