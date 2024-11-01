using System.Collections;
using UnityEngine;
using gaw241020.Presenter;
using UniRx;
using System;
using Tarahiro;

namespace gaw241020.Model
{
    public class MapModel : IMapModel
    {
        float m_MapFillPercent = 0f;
        Subject<float> changedFillSubject = new Subject<float>();


        public float mapFillPercent => m_MapFillPercent;

        public IObservable<float> ChangedFillPercent => changedFillSubject;


        public void CatchLocationUpdate(int allLocationCount, int checkedLocationCount)
        {
            Log.DebugLog("ロケーションの変更を受け取る");
            m_MapFillPercent = (float)checkedLocationCount / allLocationCount * 100f;
            changedFillSubject.OnNext(m_MapFillPercent);
        }

    }
}