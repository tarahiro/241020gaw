using System.Collections;
using UnityEngine;

namespace gaw241020
{
    public interface IStateContainerFactory 
    {
        IStateContainer CreateStateContainer();
    }
}