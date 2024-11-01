using System.Collections;
using UnityEngine;
using Zenject;
using UniRx;

namespace gaw241020.Presenter
{
    public class MapPresenter
    {
        [Inject]
        IMapModel m_MapModel;

        [Inject]
        IMapFillUiView m_MapFillUiView;

        public MapPresenter(IMapModel mapModel, IMapFillUiView mapFillUiView)
        {
            m_MapModel = mapModel;
            m_MapFillUiView = mapFillUiView;

            m_MapModel.ChangedFillPercent.Subscribe(m_MapFillUiView.UpdateFillRate);
        }
    }
}