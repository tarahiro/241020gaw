using System.Collections;
using UnityEngine;

namespace gaw241020
{
    public interface ICharacterCollisionPresenter
    {
        void EnterCharacterToLocation(GameObject townObject);

        void ExitCharacterFromLocation(GameObject townObject);
    }
}