using System.Collections;
using UnityEngine;

namespace gaw241020.State
{
    public interface IStateChanger
    {
        void ChangeState(IState state);
    }
}