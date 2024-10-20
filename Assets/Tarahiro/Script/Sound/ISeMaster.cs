using System.Collections;
using UnityEngine;

namespace Tarahiro.Sound
{
    public interface ISeMaster : IIdentifiable, IIndexable
    {

        /// <summary>
        /// このデータのIDを取得します。
        /// </summary>
        string Id { get; }

        string SePath{ get; }
    }
}