using System.Collections;
using UnityEngine;
using Zenject;
using gaw241020.State;

namespace gaw241020.Presenter
{
    public class TalkCommand : ICommand
    {
        IStateChanger m_StateChanger;

        IState m_TalkState;

        public TalkCommand(IStateChanger stateChanger, IState talkState)
        {
            m_StateChanger = stateChanger;
            m_TalkState = talkState;
        }

        public void Execute()
        {
            Talk();
        }

        void Talk()
        {
            m_StateChanger.ChangeState(m_TalkState);
        }

        public void EndCommand()
        {
            //何も書かないのはよくないが…
            //ここにステート終了処理的なのを入れるべきでは？
        }
        public bool IsCircluateCommand => false;

        public bool IsEndState => true;

        public bool IsEndCommand => true;
    }
}