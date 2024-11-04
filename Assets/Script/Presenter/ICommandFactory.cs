using System.Collections;
using UnityEngine;

namespace gaw241020.Presenter
{
    public interface ICommandFactory
    {
        ICommand CreateWalkCommand(Vector2Int direction);
        ICommand CreateShipCommand(Vector2Int direction);
        ICommand CreateTalkCommand(IState talkState);

    }
}