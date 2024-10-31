using System.Collections;
using UnityEngine;
using Tarahiro;
using gaw241020.Presenter;

namespace gaw241020.Model
{ 
    public class WarpModel : IWarpModel
    {
        string m_warpId = "";
        public void SetWarpData(string warpId)
        {
            Log.DebugAssert(m_warpId == "");
            m_warpId = warpId;
        }

        public Vector2Int GetWarpDestination()
        {
            Log.DebugLog("Fake : " + m_warpId + "の位置を返す");
            return Vector2Int.zero;
        }
    }
}