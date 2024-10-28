using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using gaw241020;

namespace gaw241020.Presenter{
    public interface ICharacterView
    {
        UniTask Move(Vector2Int vector2Int);

        bool isMoving { get; }
    }
}
