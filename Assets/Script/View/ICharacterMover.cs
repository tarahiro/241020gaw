using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using gaw241020.Presenter;


namespace gaw241020.View
{
    public interface ICharacterMover
    {
        void ChangeCharacterDisplay();


        UniTask Move(Vector2Int destination);

        bool IsMoving { get; }

        void StopMoveBehavior();
    }
}
