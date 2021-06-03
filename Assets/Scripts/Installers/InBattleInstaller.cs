using Characters;
using UnityEngine;
using Zenject;

public class InBattleInstaller : MonoInstaller
{
    [SerializeField] private MainCharacter _playerPrefab;
    [SerializeField] private BaseMonster _basicMonsterPrefab;

    public override void InstallBindings()
    {
        Container.Bind<MainCharacter>().FromComponentInNewPrefab(_playerPrefab).AsSingle().NonLazy();
        Container.Bind<BaseMonster>().To<BasicMonster>().FromComponentInNewPrefab(_basicMonsterPrefab).AsTransient()
            .NonLazy();
    }
}