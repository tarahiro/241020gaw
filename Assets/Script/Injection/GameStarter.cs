using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;
using gaw241020;
using gaw241020.View;
using gaw241020.Model;
using gaw241020.Presenter;
using gaw241020.State;

public class GameStarter : MonoInstaller
{
    [SerializeField] SpriteInformationContainer spriteInformationContainer;
    [SerializeField] CharacterInputView test;

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<LocationMasterDataProvider>().AsSingle();
        Container.BindInterfacesTo<LocationModel>().AsSingle();

        Container.BindInterfacesTo<CharacterMoverContainer>().AsSingle();
        Container.BindInterfacesTo<CharacterMoverFactory>().AsSingle();
        Container.BindInterfacesTo<CharacterModel>().AsSingle();
        Container.BindInterfacesTo<CharacterCollider>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesTo<CharacterInputView>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesTo<CharacterView>().AsSingle();
        Container.BindInterfacesTo<CharacterPresenter>().AsSingle();
        Container.BindInterfacesTo<CommandFactory>().AsSingle();
        Container.Bind<CharacterState>().AsSingle();

        Container.BindInterfacesTo<TalkPresenter>().AsSingle();
        Container.BindInterfacesTo<TalkView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<TalkState>().AsSingle();

        Container.BindInterfacesTo<MapModel>().AsSingle();
        Container.BindInterfacesTo<MapFillUiView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<MapPresenter>().AsSingle().NonLazy();


        Container.BindInterfacesTo<WarpDataProvider>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesTo<WarpModel>().AsSingle();
        Container.BindInterfacesTo<WarpPresenter>().AsSingle();
        Container.Bind<WarpState>().AsSingle();

        Container.BindInterfacesTo<StateMachine>().AsSingle();
        Container.BindInterfacesTo<StateChanger>().AsSingle();
        Container.BindInterfacesTo<StateContainerFactory>().AsSingle();
        Container.BindInterfacesTo<GridMonoBehaviourReader>().FromComponentInHierarchy().AsSingle();
        Container.BindInstance(spriteInformationContainer);
        Container.BindInterfacesTo<GridModel>().AsSingle();
        Container.Bind<GameManager>().AsSingle().NonLazy();
    }
}
