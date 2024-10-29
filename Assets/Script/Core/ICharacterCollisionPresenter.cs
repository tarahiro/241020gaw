using System.Collections;
using UnityEngine;

namespace gaw241020
{
    public interface ICharacterCollisionPresenter
    {
        void EnterCharacterToTown(GameObject townObject);

        void ExitCharacterFromTown(GameObject townObject);
    }
}