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
        [Inject]
        ITalkView m_TalkView;

        GameObject m_EndStateTelopObject;

        public EndPresenter()
        {
            m_EndStateTelopObject = GameObject.Find("EndStateTelopObject");
            m_EndStateTelopObject.SetActive(false);
        }

        public async UniTask Enter()
        {
            await UniTask.WaitForSeconds(.5f);

            await m_TalkView.DisplayTalk(
                "私は西トレウパとゼンクのほとんど全てを、地図に収めるにいたった。\n" +
                "この後、外海を回航する大帆船を求めて、東トレウパに旅立つのであるが、\n" +
                "その紀行を語るには、また後のことにしよう。"
                );

            m_EndStateTelopObject.SetActive(true);
            await UniTask.WaitForSeconds(1f);
            m_EndStateTelopObject.SetActive(false);
            Log.DebugLog("終了処理。シーンを読み込む");
            SceneManager.LoadScene("main");
        }

    }
}