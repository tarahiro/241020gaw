using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using gaw241020.Presenter;
using UnityEngine.Tilemaps;

namespace gaw241020.Model
{
    public class GridModel : IGridModel
    {

        List<Tilemap> m_TilemapList;

        public GridModel(IGridReader gridMonoBehaviourReader)
        {
            m_TilemapList = gridMonoBehaviourReader.GetTilemaps();
        }


        public bool IsWalkable(Vector2Int position)
        {
            if (position.x > 1) return false;
            return true;
        }
 public       bool IsShipable(Vector2Int position) { 
            if (position.x > 1) return false;
            return true;
        }
   public bool IsFlyable(Vector2Int position) { 
            if (position.x > 1) return false;
            return true;
        }
    }
}