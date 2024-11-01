using System.Collections;
using UnityEngine;
using Tarahiro;
using gaw241020.Presenter;
using Zenject;

namespace gaw241020.Model
{ 
    public class WarpModel : IWarpModel
    {
        [Inject]
        IWarpDataProvider m_WarpDataProvider;

        string m_warpId = "";
        public void SetWarpData(string warpId)
        {
            Log.DebugAssert(m_warpId == "");
            m_warpId = warpId;
        }

        public Vector2Int GetWarpDestination()
        {
            Log.DebugLog("Fake : " + m_warpId + "の位置を返す");
            return ConverseVector2IntToVector2(m_WarpDataProvider.GetWarpData(m_warpId).GetWarpDestination());
        }

        Vector2Int ConverseVector2IntToVector2(Vector2 vector2)
        {
            return new Vector2Int(Mathf.RoundToInt(vector2.x), Mathf.RoundToInt(vector2.y));
        }
    }
}