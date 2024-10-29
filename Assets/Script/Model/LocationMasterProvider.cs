using System.Collections;
using UnityEngine;
using Tarahiro.MasterData;

namespace gaw241020.Model
{
    public class LocationMasterDataProvider : MasterDataProvider<LocationMasterData.Record,IMasterDataRecord<ILocationMaster>>, ILocationMasterDataProvider
    {
        protected override string m_pathName => "Data/Location";
    }
}