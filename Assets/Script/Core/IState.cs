using System.Collections;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

namespace gaw241020
{
    public interface IState
    {
        UniTask Enter();

        IState RegisterStateContainer(IStateContainer stateContainer);
    }
}