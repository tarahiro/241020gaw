using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using gaw241020;
using System;

namespace gaw241020.Character {
    public interface ICharacterModel
    {
        IObservable<Vector2Int> Moved { get; }

        void Walk(Vector2Int direction);
    }
}
