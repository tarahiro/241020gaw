using System.Collections;
using UnityEngine;
using Zenject;
using UniRx;
using gaw241020.State;

namespace gaw241020.Presenter
{
    public class MapPresenter : IMapPresenter
    {
        [Inject]
        IMapModel m_MapModel;

        [Inject]
        IMapFillUiView m_MapFillUiView;

        [Inject]
        IStateChanger m_StateChanger;

        IStateContainer m_StateContainer;



        public MapPresenter(IMapModel mapModel, IMapFillUiView mapFillUiView)
        {
            m_MapModel = mapModel;
            m_MapFillUiView = mapFillUiView;

            m_MapModel.ChangedFillPercent.Subscribe(m_MapFillUiView.UpdateFillRate);
            m_MapModel.maxedMapFillPercent.Subscribe(OnMapFilled);
        }

        public void SetStateContainer(IStateContainer stateContainer)
        {
            m_StateContainer = stateContainer;
        }

        void OnMapFilled(object nullObj)
        {
            m_StateChanger.ChangeState(m_StateContainer.GetEndState);
        }
    }
}