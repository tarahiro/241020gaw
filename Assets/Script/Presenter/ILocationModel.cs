using System.Collections;
using UnityEngine;

namespace gaw241020.Presenter 
{ 
    public interface ILocationModel
    {
        string GetLocationDescription(string locationObjectName);
        string GetLocationEventSituation(string locationObjectName);
        string GetLocationEventId(string locationObjectName);

        bool IsLocationChecked(string locationObjectName);
        void CheckLocation(string locationObjectName);
    }
}