using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace gaw241020.Presenter
{
    public interface IGridReader
    {
        List<Tilemap> GetTilemaps();
    }
}