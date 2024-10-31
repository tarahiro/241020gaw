using System.Collections;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace gaw241020
{
    public interface IWarpPresenter: IStateGettable
    {
        UniTask Enter();
    }
}