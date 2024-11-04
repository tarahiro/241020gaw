using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace gaw241020.Presenter
{
    public class CharacterViewContainer : ICharacterViewContainer
    {
        [Inject]
        ICharacterViewFactory m_CharacterViewFactory;

        ICharacterView[] characterView = new ICharacterView[Enum.GetNames(typeof(CharacterPresenter.CharacterMoveState)).Length];


        public ICharacterView GetCharacterView(CharacterPresenter.CharacterMoveState moveState)

        {
            if (characterView[(int)moveState] == null)
            {
                characterView[(int)moveState] = m_CharacterViewFactory.CreateCharacterView(moveState);
            }
            return characterView[(int)moveState];
        }
    }
}
