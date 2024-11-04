using System.Collections;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace gaw241020
{
    public interface IUnlockPresenter : IStateGettable
    {
        UniTask Enter();
    }
}