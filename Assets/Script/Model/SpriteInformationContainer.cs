using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gaw241020.Model
{
    [CreateAssetMenu(menuName = "SpriteInformationContainer")]
    public class SpriteInformationContainer : ScriptableObject
    {
        [SerializeField]
        List<Sprite> m_UnWalkableTileList;
        [SerializeField]
        List<Sprite> m_UnShipableTileList;

        public List<Sprite> GetUnWalkableTileList()
        {
            return m_UnWalkableTileList;
        }
        public List<Sprite> GetUnShipableTileList()
        {
            return m_UnShipableTileList;
        }
    }
}