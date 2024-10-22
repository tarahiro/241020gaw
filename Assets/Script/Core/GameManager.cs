using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;


namespace gaw241020
{

    public class GameManager
    {
        [Inject]
        IExploreState exploreState;

        public GameManager(IExploreState exploreState)
        {
            Debug.Log("GameManagerê∂ê¨");

            exploreState.Enter().Forget();

        }

    }
}
