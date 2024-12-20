﻿using Tarahiro;
using Tarahiro.MasterData;
using System;
using System.Collections;
using UnityEngine;

namespace gaw241020.Model
{
    public class LocationMasterData : MasterDataOrderedDictionary<LocationMasterData.Record, IMasterDataRecord<ILocationMaster>>
    {
        public const string c_DataPath = "Data/Location";

        [Serializable]
        public class Record : IMasterDataRecord<ILocationMaster>, ILocationMaster
        {
            public Record(int index, string id)
            {
                m_Index = index;
                m_Id = id;
            }

            [SerializeField] int m_Index;
            [SerializeField] string m_Id;
            [SerializeField] string m_Description;
            [SerializeField] string m_EventSituation;
            [SerializeField] string m_EventId;


            public int Index => m_Index;
            public string Id => m_Id;
            public string Description => m_Description;
            public string EventSituation => m_EventSituation;
            public string EventId => m_EventId;

            public ILocationMaster GetMaster() => this;

#if UNITY_EDITOR
            public string SettableDescription { set => m_Description = value; }
            public string SettableEventSituation { set => m_EventSituation = value; }
            public string SettableEventId { set => m_EventId = value; }

#endif
        }
    }
}