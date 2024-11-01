using System.Collections;
using UnityEngine;
using gaw241020.Presenter;

namespace gaw241020.Model
{
    public class WarpData : MonoBehaviour,IWarpData
    {
        [SerializeField]
        Transform m_Destination;

        public Vector2 GetWarpDestination()
        {
            return m_Destination.position;
        }
    }
}