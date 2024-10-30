using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;


namespace gaw241020
{

    public class GameManager
    {
        [Inject]
        IStateContainerFactory m_StateContainerFactory;

        [Inject]
        IStateMachine m_StateMachine;

        IStateContainer m_StateContainer;

        public GameManager(IStateMachine stateMachie, IStateContainerFactory stateContainerFactory)
        {

            m_StateMachine = stateMachie;
            m_StateContainerFactory = stateContainerFactory;

            m_StateContainer =  stateContainerFactory.CreateStateContainer();
            m_StateMachine.SetNextState(m_StateContainer.GetCharacterState);

            m_StateMachine.Enter().Forget();
        }

    }
}
