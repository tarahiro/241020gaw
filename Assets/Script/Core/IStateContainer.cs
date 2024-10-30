using System.Collections;
using UnityEngine;

namespace gaw241020
{
    public interface IStateContainer
    {
        IState GetCharacterState { get; }
      //  IState GetTalkState { get; }
    }
}