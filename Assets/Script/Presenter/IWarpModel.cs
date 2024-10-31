using System.Collections;
using UnityEngine;

namespace gaw241020.Presenter
{
    public interface IWarpModel
    {
        void SetWarpData(string warpId);

        Vector2Int GetWarpDestination();
    }
}