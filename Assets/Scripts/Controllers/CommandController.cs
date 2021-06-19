using Commands;
using CommonEnums;
using Zenject;

namespace Controllers
{
    public class CommandController
    {
        [Inject] private DiContainer _container;

        public void ExecuteCommand(CommandType commandType)
        {
            var commandToExecute = _container.ResolveId<ICommand>(commandType);
            commandToExecute.Execute();
        }

        public void UndoCommand(CommandType commandType)
        {
            var commandToExecute = _container.ResolveId<ICommand>(commandType);
            commandToExecute.Undo();
        }
    }
}