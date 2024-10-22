using System.Collections;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Zenject;

namespace gaw241020
{
    public class ExploreState : IExploreState
    {
        [Inject]
        ICharacterPresenter characterPresenter;

        public ExploreState(ICharacterPresenter characterPresenter)
        {

        }

        public async UniTask Enter()
        {
            Debug.Log("探索開始");

            await characterPresenter.Enter();
        }
    }
}