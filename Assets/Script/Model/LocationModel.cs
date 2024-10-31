using System.Collections;
using UnityEngine;
using gaw241020.Presenter;
using Zenject;

namespace gaw241020.Model
{ 
    public class LocationModel : ILocationModel
    {
        [Inject]
        ILocationMasterDataProvider m_LocationMasterDataProvider;

        public LocationModel(ILocationMasterDataProvider locationMasterDataProvider)
        {
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
    }
}