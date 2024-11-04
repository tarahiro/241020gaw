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
        Subject<string> enteredSubject = new Subject<string>();
        Subject<string> exitedSubject = new Subject<string>();
        Subject<CharacterPresenter.CharacterMoveState> changedMoveStateSubject = new Subject<CharacterPresenter.CharacterMoveState>();

        string m_TouchedLocationName = "";
        CharacterPresenter.CharacterMoveState m_MoveState;
        bool m_CanCharacterShip;

        public IObservable<Vector2Int> Moved => movedSubject;

        public IObservable<string> EnteredInLocation => enteredSubject;
        public IObservable<string> ExitedFromLocation => exitedSubject;
        public IObservable<CharacterPresenter.CharacterMoveState> ChangedMoveState => changedMoveStateSubject;

        public Vector2Int CharacterPosition => characterPositionInt;

        public string TouchingLocationId => m_TouchedLocationName;

        public bool IsTouchingLocationExist => m_TouchedLocationName != "";

        public bool CanCharacterShip => m_CanCharacterShip;
        public CharacterPresenter.CharacterMoveState GetMoveState => m_MoveState;

        public CharacterModel()
        {
            characterPositionInt = Vector2Int.zero; 
        }
        
        public void FakeWarp(Vector2Int destination)
        {
            characterPositionInt = destination;
            movedSubject.OnNext(destination);
        }


        public void Move(Vector2Int direction)
        {
            characterPositionInt += direction;
            movedSubject.OnNext(characterPositionInt);
        }

        public void EnterCharacterToLocation(string locationName)
        {
            Debug.Log("キャラクターがTownに触れたことをModelが取得");
            Log.DebugAssert(m_TouchedLocationName == "");
            m_TouchedLocationName = locationName;
            enteredSubject.OnNext(locationName);
        }

        public void ExitCharacterFromLocation(string locationName)
        {
            m_TouchedLocationName = "";
            exitedSubject.OnNext(locationName);
        }

        public void SetCharacterMoveState(CharacterPresenter.CharacterMoveState moveState)
        {
            Log.DebugLog(moveState.ToString());
            m_MoveState = moveState;
            changedMoveStateSubject.OnNext(moveState);
        }

        public void EnableCharacterShip()
        {
            m_CanCharacterShip = true;
        }
    }
}
