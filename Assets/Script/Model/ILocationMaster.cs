using System.Collections;
using UnityEngine;
using Tarahiro;

namespace gaw241020.Model
{
    public interface ILocationMaster : IIdentifiable, IIndexable
    {

        /// <summary>
        /// このデータのIDを取得します。
        /// </summary>
        string Id { get; }

        string Description{ get; }
    }
}