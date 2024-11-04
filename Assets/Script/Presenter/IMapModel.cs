using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using gaw241020;
using System;

namespace gaw241020.Presenter
{
    public interface IMapModel
    {
        float mapFillPercent { get; }

        void CatchLocationUpdate(int allLocationCount, int checkedLocationCount);

        IObservable<float> ChangedFillPercent { get; }

        IObservable<object> maxedMapFillPercent { get; }
    }
}