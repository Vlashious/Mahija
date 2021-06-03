using Characters;
using UnityEngine;
using Zenject;

public class InBattleInstaller : MonoInstaller
{
    [SerializeField] private MainCharacter _playerPrefab;
    public override void InstallBindings()
    {
        Container.Bind<MainCharacter>().FromComponentInNewPrefab(_playerPrefab).AsSingle().NonLazy();
    }
}