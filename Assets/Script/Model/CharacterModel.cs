using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gaw241020;
using gaw241020.Presenter;
using UniRx;
using System;

namespace gaw241020.Model {
    public class CharacterModel : ICharacterModel
    {
        Vector2Int characterPositionInt;
        Subject<Vector2Int> movedSubject = new Subject<Vector2Int>();

        public IObservable<Vector2Int> Moved => movedSubject;

        public Vector2Int CharacterPosition => characterPositionInt;

        public CharacterModel()
        {
            characterPositionInt = Vector2Int.zero; 
        }


        public void Walk(Vector2Int direction)
        {
            characterPositionInt += direction;
            movedSubject.OnNext(characterPositionInt);
        }
    }
}
