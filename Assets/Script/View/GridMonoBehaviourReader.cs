using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Tarahiro;
using Zenject;
using UnityEngine.Tilemaps;
using gaw241020.Presenter;

namespace gaw241020.View
{
    public class GridMonoBehaviourReader : MonoBehaviour,IGridReader
    {
        [SerializeField]
        Grid m_Grid;

        Tilemap[] m_TilemapArray;


        void ReadTilemap()
        {
            Log.DebugLog("ヒエラルキーからタイルマップを読み込み");

            Log.DebugAssert(m_Grid != null);
            m_TilemapArray = m_Grid.GetComponentsInChildren<Tilemap>();
        }

        public List<Tilemap> GetTilemaps()
        {
            Debug.Log("タイルマップを渡す");

            if(m_TilemapArray == null)
            {
                ReadTilemap();
            }
            Log.DebugAssert(m_TilemapArray != null);
            Log.DebugAssert(m_TilemapArray.Length > 0);
            return m_TilemapArray.ToList();
        }


    }
}