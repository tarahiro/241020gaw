using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;
using gaw241020;
using gaw241020.View;
using gaw241020.Model;
using gaw241020.Presenter;

public class GameStarter : MonoInstaller
{

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<CharacterModel>().AsSingle();
        Container.BindInterfacesTo<CharacterView>().AsSingle();
        Container.BindInterfacesTo<CharacterPresenter>().AsSingle();
        Container.BindInterfacesTo<ExploreState>().AsSingle();
        Container.BindInterfacesTo<GridMonoBehaviourReader>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesTo<GridModel>().AsSingle();
        Container.Bind<GameManager>().AsSingle().NonLazy();
    }
}
