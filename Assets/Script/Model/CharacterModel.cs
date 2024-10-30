using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gaw241020;
using gaw241020.Presenter;
using UniRx;
using System;
using Tarahiro;

namespace gaw241020.Model {
    public class CharacterModel : ICharacterModel
    {
        Vector2Int characterPositionInt;
        Subject<Vector2Int> movedSubject = new Subject<Vector2Int>();

        string m_TouchedLocationName = "";

        public IObservable<Vector2Int> Moved => movedSubject;

        public Vector2Int CharacterPosition => characterPositionInt;

        public string TouchingLocationId => m_TouchedLocationName;

        public bool IsTouchingLocationExist => m_TouchedLocationName != "";

        public CharacterModel()
        {
            characterPositionInt = Vector2Int.zero; 
        }


        public void Walk(Vector2Int direction)
        {
            characterPositionInt += direction;
            movedSubject.OnNext(characterPositionInt);
        }

        public void EnterCharacterToLocation(string locationName)
        {
            Debug.Log("キャラクターがTownに触れたことをModelが取得");
            Log.DebugAssert(m_TouchedLocationName == "");
            m_TouchedLocationName = locationName;
        }
        public void ExitCharacterFromLocation(string locationName)
        {
            Log.DebugAssert(m_TouchedLocationName == locationName);
            m_TouchedLocationName = "";
        }
    }
}
