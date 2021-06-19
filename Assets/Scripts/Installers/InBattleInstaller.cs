using Characters;
using Magic;
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
        Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
        Container.Bind<CharacterConfig>().FromScriptableObjectResource("CharacterConfig").AsSingle();
        Container.Bind<SpellConfig>().FromScriptableObjectResource("SpellConfig").AsSingle();
        Container.Bind<MainCharacter>().FromComponentInNewPrefab(_playerPrefab).AsSingle().NonLazy();
        Container.BindFactory<BasicMonster.BasicMonsterInfo, BasicMonster, BasicMonster.Factory>()
            .FromComponentInNewPrefab(_basicMonsterPrefab)
            .AsTransient();
        Container.BindFactory<AutoAttack.AutoAttackInfo, AutoAttack, AutoAttack.Factory>()
            .FromComponentInNewPrefab(_autoAttackPrefab)
            .AsTransient();
    }
}