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
        Container.Bind<ICommand>().WithId(CommandType.EnterTheBattle).To<EnterBattleCommand>().AsSingle();
        Container.Bind<ICommand>().WithId(CommandType.ExitTheBattle).To<ExitBattleCommand>().AsSingle();
        Container.Bind<ICommand>().WithId(CommandType.PauseTheBattle).To<PauseTheBattleCommand>().AsSingle();
        Container.Bind<ICommand>().WithId(CommandType.DamageThePlayer).To<DamageThePlayerCommand>().AsTransient();
    }
}