using System.Collections;
using UnityEngine;

namespace gaw241020
{
    public interface IStateGettable
    {
        void SetStateContainer(IStateContainer stateContainer);
    }
}