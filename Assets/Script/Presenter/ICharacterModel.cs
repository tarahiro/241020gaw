using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using gaw241020;
using System;

namespace gaw241020.Presenter{
    public interface ICharacterModel
    {
        IObservable<Vector2Int> Moved { get; }
        IObservable<string> EnteredInLocation { get; }
        IObservable<string> ExitedFromLocation { get; }

        Vector2Int CharacterPosition { get; }

        String TouchingLocationId { get; }

        bool IsTouchingLocationExist { get; }

        void FakeWarp(Vector2Int destination);

        void Walk(Vector2Int direction);

        void EnterCharacterToLocation(string locationName);

        void ExitCharacterFromLocation(string locationName);
    }
}
