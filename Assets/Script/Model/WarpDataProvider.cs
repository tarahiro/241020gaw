using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using gaw241020.Presenter;
using Zenject;

namespace gaw241020.Model
{
    public class WarpDataProvider : MonoBehaviour,IWarpDataProvider
    {
        List<WarpData> m_WarpDataList;

        [Inject]
        public void Construct()
        {
            m_WarpDataList = new List<WarpData>();
            for(int i= 0; i < transform.childCount; i++)
            {
                if(transform.GetChild(i).GetComponent<WarpData>() != null)
                {
                    m_WarpDataList.Add(transform.GetChild(i).GetComponent<WarpData>());
                }
            }
           
        }


        public IWarpData GetWarpData(string warpId)
        {
            return m_WarpDataList.Find(x => x.gameObject.name == warpId);
        }
    }
}