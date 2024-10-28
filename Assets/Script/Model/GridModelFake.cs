using System.Collections;
using UnityEngine;
using gaw241020.Presenter;

namespace gaw241020.Model
{
    public class GridModelFake : IGridModel
    {
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