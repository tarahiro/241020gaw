using System.Collections;
using UnityEngine;

namespace gaw241020.Presenter
{
    public interface ICommandFactory
    {
        ICommand CreateMoveCommand(Vector2Int direction);
        ICommand CreateTalkCommand(IState talkState);

    }
}