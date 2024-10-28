using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using gaw241020;
using UnityEngine.Tilemaps;

namespace gaw241020.Presenter{
    public interface IGridModel
    {

        bool IsWalkable(Vector2Int position);
        bool IsShipable(Vector2Int position);
        bool IsFlyable(Vector2Int position);

    }
}
