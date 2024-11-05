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

        public GameManager(IStateMachine stateMachine, IStateContainerFactory stateContainerFactory)
        {
            m_StateMachine = stateMachine;

            m_StateContainer =  stateContainerFactory.CreateStateContainer();
            m_StateMachine.SetNextState(m_StateContainer.GetCharacterState);

            m_StateMachine.Enter().Forget();

            SoundManager.PlayBGM("Field",0);
        }

    }
}
