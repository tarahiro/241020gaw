using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using gaw241020.Presenter;

namespace gaw241020.Model
{
    public class WarpDataProvider : MonoBehaviour,IWarpDataProvider
    {
        [SerializeField]
        List<WarpData> m_WarpDataList;

        public IWarpData GetWarpData(string warpId)
        {
            return m_WarpDataList.Find(x => x.gameObject.name == warpId);
        }
    }
}