using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using gaw241020;
using System;
using UniRx;

namespace gaw241020.Character {
    public class CharacterModel : ICharacterModel
    {
        Vector2Int characterPositionInt;
        Subject<Vector2Int> movedSubject = new Subject<Vector2Int>();

        public IObservable<Vector2Int> Moved => movedSubject;

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
