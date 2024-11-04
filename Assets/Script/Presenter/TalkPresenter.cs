using System.Collections;
using UnityEngine;
using gaw241020;
using gaw241020.State;
using Zenject;
using Tarahiro;
using Cysharp.Threading.Tasks;

namespace gaw241020.Presenter
{
    public class TalkPresenter : ITalkPresenter
    {
        [Inject]
        ICharacterModel m_CharacterModel;

        [Inject]
        ILocationModel m_LocationModel;

        [Inject]
        ITalkView m_TalkView;

        [Inject]
        IStateChanger m_StateChanger;

        [Inject]
        IWarpModel m_WarpModel;

        [Inject]
        IUnlockModel m_UnlockModel;

        IStateContainer m_StateContainer;
        
        public async UniTask Enter()
        {
            string locationId = m_CharacterModel.TouchingLocationId;

            Log.DebugAssert(locationId != "");

            if (!m_LocationModel.IsLocationChecked(locationId))
            {
                m_LocationModel.CheckLocation(locationId);
            }

            
            await m_TalkView.DisplayTalk(
                m_LocationModel.GetLocationDescription(locationId)
                );


            //ロケーションによって次のState遷移先が異なる
            string eventSituation = m_LocationModel.GetLocationEventSituation(locationId);
            switch (eventSituation)
            {
                case "Warp":
                    m_WarpModel.SetWarpData(
                        m_LocationModel.GetLocationEventId(locationId)
                        );
                    m_StateChanger.ChangeState(m_StateContainer.GetWarpState);
                    break;

                case "Unlock":
                    m_UnlockModel.SetUnlockContentId(
                         m_LocationModel.GetLocationEventId(locationId));
                    m_StateChanger.ChangeState(m_StateContainer.GetUnlockState);
                    break;



                case "None":
                    Log.DebugLog("特になし");
                    m_StateChanger.ChangeState(m_StateContainer.GetCharacterState);
                    break;

                default:
                    Log.DebugAssert(false);
                    break;
            }

            //次のStateへ遷移

            Log.DebugAssert(m_StateChanger != null);
            Log.DebugAssert(m_StateContainer != null);



        }

        public void SetStateContainer(IStateContainer stateContainer)
        {
            m_StateContainer = stateContainer;
        }

    }
}