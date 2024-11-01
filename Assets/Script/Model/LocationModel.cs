using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using gaw241020.Presenter;
using Zenject;

namespace gaw241020.Model
{ 
    public class LocationModel : ILocationModel
    {
        [Inject]
        ILocationMasterDataProvider m_LocationMasterDataProvider;

        [Inject]
        IMapModel m_MapModel;

        Dictionary<string,bool> checkedFlag = new Dictionary<string,bool>();


        public LocationModel(ILocationMasterDataProvider locationMasterDataProvider)
        {
            for (int i = 0; i < locationMasterDataProvider.Count; i++)
            {
                checkedFlag.Add(locationMasterDataProvider.TryGetFromIndex(i).GetMaster().Id, false);
            }
        }

        public string GetLocationDescription(string locationName)
        {
            return m_LocationMasterDataProvider.TryGetFromId(locationName).GetMaster().Description;
        }
        public string GetLocationEventSituation(string locationName)
        {
            return m_LocationMasterDataProvider.TryGetFromId(locationName).GetMaster().EventSituation;
        }
        public string GetLocationEventId(string locationName)
        {
            return m_LocationMasterDataProvider.TryGetFromId(locationName).GetMaster().EventId;
        }

        public void CheckLocation(string locationObjectName)
        {
            checkedFlag[locationObjectName] = true;
            m_MapModel.CatchLocationUpdate(m_LocationMasterDataProvider.Count, checkedFlag.Count(x => x.Value));
        }
        public bool IsLocationChecked(string locationObjectName)
        {
            return checkedFlag[locationObjectName];
        }
    }
}