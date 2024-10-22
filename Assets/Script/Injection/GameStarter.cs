using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using gaw241020;
using gaw241020.Character;

public class GameStarter : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<CharacterModel>().AsSingle();
        Container.BindInterfacesTo<CharacterView>().AsSingle();
        Container.BindInterfacesTo<CharacterPresenter>().AsSingle();
        Container.BindInterfacesTo<ExploreState>().AsSingle();
        Container.Bind<GameManager>().AsSingle().NonLazy();
    }
}
