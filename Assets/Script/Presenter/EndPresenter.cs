using System.Collections;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Zenject;
using Tarahiro;
using gaw241020.State;
using UnityEngine.SceneManagement;

namespace gaw241020.Presenter { 
    public class EndPresenter : IEndPresenter
    {

        public async UniTask Enter()
        {
            Log.DebugLog("終了処理。シーンを読み込む");
            SceneManager.LoadScene("main");
        }

    }
}