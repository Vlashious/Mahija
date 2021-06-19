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
    }
}