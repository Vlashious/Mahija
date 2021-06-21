using Commands;
using CommonEnums;
using Controllers;
using Zenject;

public class CommandInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<CommandController>().AsSingle();

        Container.Bind<ICommand>().WithId(CommandType.InitLoad).FromComponentInHierarchy().AsSingle();
        Container.Bind<ICommand>().WithId(CommandType.EnterBattle).To<EnterBattleCommand>().AsSingle();
        Container.Bind<ICommand>().WithId(CommandType.ExitBattle).To<ExitBattleCommand>().AsSingle();
        Container.Bind<ICommand>().WithId(CommandType.PauseBattle).To<PauseBattleCommand>().AsSingle();

        Container.Bind<ICommandWithParameter>().WithId(CommandType.AddScore).To<AddScoreCommand>().AsSingle();
        Container.Bind<ICommandWithParameter>().WithId(CommandType.AddElementToSpell).To<AddElementToSpellCommand>().AsSingle();
        Container.Bind<ICommandWithParameter>().WithId(CommandType.RemoveElementFromSpell).To<RemoveElementFromSpellCommand>().AsSingle();
    }
}