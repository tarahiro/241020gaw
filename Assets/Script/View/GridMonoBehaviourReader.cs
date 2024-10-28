using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using UnityEngine.Tilemaps;
using gaw241020.Presenter;

namespace gaw241020.View
{
    public class GridMonoBehaviourReader : MonoBehaviour,IGridMonoBehaviourReader
    {
        
        [SerializeField]
        private Grid m_Grid;

        Tilemap[] m_TilemapArray;


        public void FindTilemap()
        {
            Debug.Log("ヒエラルキーから読み込み");

            Debug.LogAssertion(m_Grid);
            m_TilemapArray = m_Grid.GetComponentsInChildren<Tilemap>();
        }

        public List<Tilemap> GetTilemaps()
        {
            Debug.Log("タイルマップを渡す");

            if(m_TilemapArray == null)
            {
                FindTilemap();
            }
            Debug.LogAssertion(m_TilemapArray);
            return m_TilemapArray.ToList();
        }


    }
}