using System.Collections;
using UnityEngine;

namespace gaw241020.Presenter
{
    public interface IWarpDataProvider
    {
        IWarpData GetWarpData(string warpId);
    }
}