using System.Collections;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace gaw241020
{
    public interface IStateMachine
    {
        UniTask Enter();

        void SetNextState(IState state);
    }
}