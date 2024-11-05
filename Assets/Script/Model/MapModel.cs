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
        Subject<object> maxedMapFillSubject = new Subject<object>();


        public float mapFillPercent => m_MapFillPercent;

        public IObservable<float> ChangedFillPercent => changedFillSubject;

        public IObservable<object> maxedMapFillPercent => maxedMapFillSubject;


        public void CatchLocationUpdate(int allLocationCount, int checkedLocationCount)
        {
            Log.DebugLog("ロケーションの変更を受け取る");
            m_MapFillPercent = (float)checkedLocationCount / allLocationCount * 100f;
            changedFillSubject.OnNext(m_MapFillPercent);
            if(m_MapFillPercent >= 100f)
            {
                Log.DebugLog("Max");
                maxedMapFillSubject.OnNext(null);
            }
            else {
                /*
                Log.DebugLog("Fake");
                maxedMapFillSubject.OnNext(null);
                */
            }
        }

    }
}