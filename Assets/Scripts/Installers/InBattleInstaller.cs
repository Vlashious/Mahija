using Characters;
using Magic.Spells;
using UnityEngine;
using Zenject;

public class InBattleInstaller : MonoInstaller
{
    [SerializeField] private MainCharacter _playerPrefab;
    [SerializeField] private BaseMonster _basicMonsterPrefab;
    [SerializeField] private BaseSpell _autoAttackPrefab;

    public override void InstallBindings()
    {
        Container.Bind<MainCharacter>().FromComponentInNewPrefab(_playerPrefab).AsSingle().NonLazy();
        Container.BindFactory<BasicMonster, BasicMonster.Factory>().FromComponentInNewPrefab(_basicMonsterPrefab)
            .AsTransient();
        Container.BindFactory<AutoAttack.AutoAttackInfo, AutoAttack, AutoAttack.Factory>()
            .FromComponentInNewPrefab(_autoAttackPrefab)
            .AsTransient();

        Container.Resolve<BasicMonster.Factory>().Create();
    }
}