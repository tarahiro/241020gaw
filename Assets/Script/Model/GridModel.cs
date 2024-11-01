using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using gaw241020.Presenter;
using Tarahiro;
using UnityEngine.Tilemaps;

namespace gaw241020.Model
{
    public class GridModel : IGridModel
    {

        ILocationMasterDataProvider m_LocationMasterDataProvider;

        List<Tilemap> m_TilemapList;
        int m_GroundLayer;

        List<Sprite> UnWalkableTileList;
        List<Sprite> UnShipableTileList;


        public GridModel(IGridReader gridMonoBehaviourReader, SpriteInformationContainer spriteInformationContainer, ILocationMasterDataProvider locationMasterDataProvider)
        {
            m_LocationMasterDataProvider = locationMasterDataProvider;

            m_TilemapList = gridMonoBehaviourReader.GetTilemaps();
            UnWalkableTileList = spriteInformationContainer.GetUnWalkableTileList();
            UnShipableTileList = spriteInformationContainer.GetUnShipableTileList();

            for(int i = 0; i < m_TilemapList.Count; i++)
            {
                if(m_TilemapList[i].name == "TilemapGround")
                {
                    m_GroundLayer = i;
                    break;
                }
            }
        }


        public bool IsWalkable(Vector2Int position)
        {
            if(!isInTileMap(position, m_TilemapList))
            {
                return false;
            }

            for(int i = 0; i < m_TilemapList.Count;i++)
            {
                if (m_TilemapList[i].GetTile((Vector3Int)position) != null)
                {
                    Debug.Log(m_TilemapList[i].GetTile((Vector3Int)position).name);
                    if (UnWalkableTileList.Exists(x => x.name == m_TilemapList[i].GetTile((Vector3Int)position).name))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool IsShipable(Vector2Int position)
        {
            if (!isInTileMap(position, m_TilemapList))
            {
                return false;
            }

            for (int i = 0; i < m_TilemapList.Count; i++)
            {
                if (m_TilemapList[i].GetTile((Vector3Int)position) != null)
                {
                    if (UnShipableTileList.Exists(x => x.name == m_TilemapList[i].GetTile((Vector3Int)position).name))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsFlyable(Vector2Int position)
        {
            if (!isInTileMap(position, m_TilemapList))
            {
                return false;
            }
            return true;
        }

        bool isInTileMap(Vector2Int position, List<Tilemap> tilemapList)
        {

                if(position.x < m_TilemapList[m_GroundLayer].origin.x 
                || position.x > m_TilemapList[m_GroundLayer].origin.x + m_TilemapList[m_GroundLayer].size.x)
                {
                    Debug.Log("xが範囲を超えている");
                    return false;
                }
                if(position.y < m_TilemapList[m_GroundLayer].origin.y 
                || position.y > m_TilemapList[m_GroundLayer].origin.y + m_TilemapList[m_GroundLayer].size.y)
                {
                    Debug.Log("yが範囲を超えている");
                    return false;
                }
            return true;

        }
    }
}